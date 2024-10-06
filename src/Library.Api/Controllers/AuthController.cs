using Library.Application.User.Command;
using Library.Application.User.Query;
using Library.Contracts.Github;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Web;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ISender _mediator;
        public AuthController(HttpClient httpClient, IConfiguration configuration, ISender mediator)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _mediator = mediator;
        }
 

        [HttpGet("login")]
        public IActionResult Login()
        {
            var redirectUri = "http://localhost:8084/api/auth/token";
            var clientId = "Ov23liREWbwVTVDhdmyu"; // replace with your Client ID
            var requestUrl = $"https://github.com/login/oauth/authorize?client_id={clientId}&redirect_uri={redirectUri}";
            return Redirect(requestUrl);
        }

        [HttpGet("token")]
        public async Task<IActionResult> GetCode(string code)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://github.com/login/oauth/access_token");
            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "client_id", "Ov23liREWbwVTVDhdmyu" },
            { "client_secret", "8ba0b2948434dc91293899d04142815b5cf6cd0e" },
            { "code", code },
             { "scope", "user:email" }
            });

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();

                // Parse the string using HttpUtility.ParseQueryString
                var queryParams = HttpUtility.ParseQueryString(responseBody);

                // Extract the access_token
                string accessToken = queryParams["access_token"];

                var githubEmails = await GetGitHubEmailsAsync(accessToken);

                var userProfile = githubEmails.FirstOrDefault();

                var command = new GetUserByEmailCommand(userProfile.Email);

                var userExist = await _mediator.Send(command);

                if (userExist.IsError)
                {
                    var user = await _mediator.Send(new CreateUserCommand(userProfile.Email));
                }



                return Content($"$email: {userProfile.Email} \n accessToken: {accessToken} \n jwtToken: {GenerateJwtToken(userProfile.Email, accessToken)}", "application/json");
            }

            return BadRequest("Error retrieving access token.");
        }
        private string GenerateJwtToken(string email, string accessToken)
        {
             
            var secretKey = _configuration["JWT"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

             
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            
            var claims = new[]
            {
            new Claim("user_email", email),
            new Claim("access_token", accessToken)
        };

            // Create the token
            var token = new JwtSecurityToken(
                
                claims: claims,
                expires: DateTime.Now.AddHours(1), // Token expiration time
                signingCredentials: credentials
            );

            // Return the token as a string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private static async Task<GitHubProfile[]> GetGitHubEmailsAsync(string accessToken)
        {
            using (var httpClient = new HttpClient())
            {

                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("YourApp");

                // Make the GET request to GitHub API
                var response = await httpClient.GetAsync("https://api.github.com/user/emails");

                if (response.IsSuccessStatusCode)
                {
                     
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON string into an array of GitHubEmail objects
                    var emails = JsonSerializer.Deserialize<GitHubProfile[]>(jsonResponse, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return emails;
                }
                else
                {
                     
                    return null;
                }
            }
        }
    }
}
 

