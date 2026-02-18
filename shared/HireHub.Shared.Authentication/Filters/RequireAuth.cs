using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HireHub.Shared.Authentication.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class RequireAuthAttribute : Attribute, IAuthorizationFilter
{
    public string[] Roles { get; set; } = [];

    public RequireAuthAttribute() { }

    public RequireAuthAttribute(string[] roles)
    {
        Roles = roles;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (context.HttpContext.User?.Identity == null || !context.HttpContext.User.Identity.IsAuthenticated)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Result = new ContentResult
            {
                StatusCode = StatusCodes.Status401Unauthorized,
                Content = "Unauthorized"
            };
            return;
        }

        // Optional: check roles
        if (!(Roles.Length == 0) && !IsInRole(context.HttpContext.User))
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
            context.Result = new ContentResult
            {
                StatusCode = StatusCodes.Status403Forbidden,
                Content = "Forbidden"
            };
            return;
        }
    }

    private bool IsInRole(ClaimsPrincipal user)
    {
        foreach (string role in Roles) 
        {
            if (user.IsInRole(role))
                return true;
        }
        return false;
    }
}
