using System.Net;
using System.Text.Json;
using HireHub.Shared.Middleware.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HireHub.Shared.Middleware.Middlewares;

internal class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Unhandled exception: {ex.Message}");
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var errorResponse = new ErrorResponse
        {
            StatusCode = context.Response.StatusCode,
            Message = _env.IsDevelopment() ? ex.Message : "An unexpected error occurred.",
            StackTrace = _env.IsDevelopment() ? ex.StackTrace : null,
            TraceId = context.TraceIdentifier
        };

        var json = JsonSerializer.Serialize(errorResponse);
        await context.Response.WriteAsync(json);
    }
}