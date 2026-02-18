using HireHub.Shared.Persistence.Interface;
using HireHub.Shared.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HireHub.Shared.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddHireHubPersistence(
        this IServiceCollection services)
    {
        services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        return services;
    }
}
