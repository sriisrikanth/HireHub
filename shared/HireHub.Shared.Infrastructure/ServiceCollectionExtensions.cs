using HireHub.Shared.Infrastructure.Interface;
using HireHub.Shared.Infrastructure.Models;
using HireHub.Shared.Infrastructure.Service;
using Microsoft.Extensions.DependencyInjection;

namespace HireHub.Shared.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHireHubEmailService(
        this IServiceCollection services, EmailConfig emailConfig)
    {
        services.AddSingleton<IHireHubEmailService>(new HireHubEmailService(emailConfig));
        return services;
    }

    public static IServiceCollection AddAzureEmailService(
        this IServiceCollection services, AzureLogicApp azureLogicApp)
    {
        services.AddSingleton<IAzureEmailService>(new AzureEmailService(azureLogicApp));
        return services;
    }
}
