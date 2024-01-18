using MultiTenancyDemo.Contracts.Data;

namespace MultiTenancyDemo.Contracts.Resolvers
{
    public interface ITenantResolver
    {
        Task<Tenant> ResolveAsync();
    }
}
