using System.Security.Claims;
using HireHub.Shared.Authentication.Interface;
using Microsoft.AspNetCore.Http;

namespace HireHub.Shared.Authentication.Middleware;

internal class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IJwtTokenService _jwtService;

    public AuthenticationMiddleware(RequestDelegate next, IJwtTokenService jwtService)
    {
        _next = next;
        _jwtService = jwtService;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await Process(context);
    }

    private async Task Process(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (!string.IsNullOrEmpty(token))
        {
            var claims = _jwtService.ValidateToken(token);
            if (claims != null)
            {
                var identity = new ClaimsIdentity(claims, "Jwt HireHub");
                context.User = new ClaimsPrincipal(identity);

                context.Items["UserId"] = claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
                context.Items["Role"] = claims.First(x => x.Type == ClaimTypes.Role).Value;
            }
        }

        await _next(context);
    }

}
