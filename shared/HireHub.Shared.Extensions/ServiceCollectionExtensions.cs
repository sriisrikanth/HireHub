using Microsoft.Extensions.DependencyInjection;
using HireHub.Shared.Authentication;
using HireHub.Shared.Authentication.Models;
using HireHub.Shared.Persistence;
using HireHub.Shared.Infrastructure.Models;
using HireHub.Shared.Infrastructure;

namespace HireHub.Shared.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Added HireHub Auth, HireHub Persistence, HireHub Infra
    /// </summary>
    /// <param name="services"></param>
    /// <param name="jwtSettings"></param>
    /// <param name="emailConfig"></param>
    /// <param name="azureLogicApp"></param>
    /// <returns></returns>
    public static IServiceCollection AddHireHubShared(
        this IServiceCollection services,
        JwtSettings? jwtSettings = null, EmailConfig? emailConfig = null, AzureLogicApp? azureLogicApp = null)
    {
        // Authentication
        if (jwtSettings != null)
        services.AddHireHubAuth(jwtSettings);

        // Persistence
        services.AddHireHubPersistence();

        // Infrastructure
        if (emailConfig != null) 
            services.AddHireHubEmailService(emailConfig);
        if (azureLogicApp != null)
            services.AddAzureEmailService(azureLogicApp);

        return services;
    }

}
