using MultiTenancyDemo.Data;

namespace MultiTenancyDemo.Contracts.Factories
{
    public interface ITenantDbContextFactory
    {
        TenantDbContext GetDbContext();
    }
}
