using MultiTenancyDemo.Contracts.Factories;
using MultiTenancyDemo.Contracts.Options;
using MultiTenancyDemo.Contracts.Resolvers;
using MultiTenancyDemo.Data.Factories;
using MultiTenancyDemo.Infrastructure.Resolvers;

namespace MultiTenancyDemo.Extensions
{
    public static class ConfigurationServiceCollectionExtensions
    {
        public static IServiceCollection AddFactories(this IServiceCollection services)
        {
            services.AddScoped<ITenantDbContextFactory, TenantDbContextFactory>();

            return services;
        }
     
        public static IServiceCollection AddMyOptions(this IServiceCollection services)
        {
            services.AddOptions<MyAppOptions>().BindConfiguration("MyAppSettings");

            return services;
        }

        public static IServiceCollection AddResolvers(this IServiceCollection services)
        {
            services.AddScoped<ITenantResolver, SubdomainTenantResolver>();

            return services;
        }
    }
}
