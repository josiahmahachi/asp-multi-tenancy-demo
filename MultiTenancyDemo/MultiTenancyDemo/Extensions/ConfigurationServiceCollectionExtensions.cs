using MultiTenancyDemo.Contracts.Options;
using MultiTenancyDemo.Contracts.Resolvers;
using MultiTenancyDemo.Infrastructure.Resolvers;

namespace MultiTenancyDemo.Extensions
{
public static class ConfigurationServiceCollectionExtensions
{
    public static IServiceCollection AddMyOptions(this IServiceCollection services)
    {
        services.AddOptions<MyAppOptions>().BindConfiguration("MyAppSettings");

        return services;
    }

    public static IServiceCollection AddReolvers(this IServiceCollection services)
    {
        services.AddScoped<ITenantResolver, SubdomainTenantResolver>();

        return services;
    }
}
}
