using HireHub.Shared.Authentication.Interface;
using HireHub.Shared.Authentication.Models;
using HireHub.Shared.Authentication.Service;
using Microsoft.Extensions.DependencyInjection;

namespace HireHub.Shared.Authentication;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHireHubAuth(
        this IServiceCollection services,
        JwtSettings jwtSettings)
    {
        // Authentication
        services.AddSingleton<IJwtTokenService>(new JwtTokenService(jwtSettings));

        return services;
    }
}