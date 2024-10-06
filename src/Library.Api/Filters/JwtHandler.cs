using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Library.Api.Filters
{ 
        public class JwtHandler  
        {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public JwtHandler(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
               
                var claimsPrincipal = ValidateToken(token);

                if (claimsPrincipal != null)
                {
                    var userEmail = claimsPrincipal.Claims.First(x => x.Type == "user_email")?.Value;

                    context.Items["User"] = userEmail;


                }
            }

           
            await _next(context);
        }

        private ClaimsPrincipal ValidateToken(string token)
        {
            try
            {
                var secretKey = _configuration["JWT"];
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    
                    IssuerSigningKey = key
                };

                
                var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                

                return claimsPrincipal;
            }
            catch (Exception ex)
            {
                // Token validation failed, return null
                Console.WriteLine($"Token validation failed: {ex.Message}");
                return null;
            }
        }
    }
     
}
