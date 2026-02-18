using HireHub.Shared.Middleware.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace HireHub.Shared.Middleware;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseHireHubRequestLogging(this IApplicationBuilder app)
    {
        return app.UseMiddleware<RequestLoggingMiddleware>();
    }

    public static IApplicationBuilder UseHireHubGlobalException(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
