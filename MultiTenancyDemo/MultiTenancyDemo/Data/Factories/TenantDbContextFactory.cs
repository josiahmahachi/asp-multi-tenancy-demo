using Microsoft.EntityFrameworkCore;
using MultiTenancyDemo.Contracts.Factories;

namespace MultiTenancyDemo.Data.Factories
{
public class TenantDbContextFactory : ITenantDbContextFactory
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private TenantDbContext? _dbContext;

    public TenantDbContextFactory(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public TenantDbContext GetDbContext()
    {
        if (_dbContext is not null) return _dbContext;

        var connectionString = _httpContextAccessor.HttpContext.Items["ConnectionString"] as string;

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string not found in HttpContext.");
        }

        var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();

        optionsBuilder.UseSqlServer(connectionString);

        _dbContext = new TenantDbContext(optionsBuilder.Options);

        return _dbContext;
    }
}
}
