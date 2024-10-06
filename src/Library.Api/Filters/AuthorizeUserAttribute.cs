using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Library.Api.Filters
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeUserAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            var user = filterContext.HttpContext.Items["User"];

            if (user == null)
            {
                filterContext.Result = new JsonResult(new { message = "Unothorized" })
                { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
