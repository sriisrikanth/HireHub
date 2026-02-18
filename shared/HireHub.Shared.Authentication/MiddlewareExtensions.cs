using HireHub.Shared.Authentication.Middleware;
using Microsoft.AspNetCore.Builder;

namespace HireHub.Shared.Authentication;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseHireHubAuth(this IApplicationBuilder app)
    {
        return app.UseMiddleware<AuthenticationMiddleware>();
    }
}
