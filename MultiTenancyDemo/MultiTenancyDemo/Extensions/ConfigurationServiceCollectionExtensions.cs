using MultiTenancyDemo.Contracts.Options;

namespace MultiTenancyDemo.Extensions
{
    public static class ConfigurationServiceCollectionExtensions
    {
        public static IServiceCollection AddMyOptions(this IServiceCollection services)
        {
            services.AddOptions<MyAppOptions>().BindConfiguration("MyAppSettings");

            return services;
        }
    }
}
