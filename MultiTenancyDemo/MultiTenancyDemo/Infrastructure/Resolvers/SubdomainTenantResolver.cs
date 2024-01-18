using Microsoft.EntityFrameworkCore;
using MultiTenancyDemo.Contracts.Data;
using MultiTenancyDemo.Contracts.Resolvers;
using MultiTenancyDemo.Data;

namespace MultiTenancyDemo.Infrastructure.Resolvers
{
    public class SubdomainTenantResolver : ITenantResolver
    {
        private readonly PlatformDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SubdomainTenantResolver(PlatformDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Resolves the tenant from the sub-domain
        /// </summary>
        /// <returns>An instance of the Tenant</returns>
        /// <exception cref="Exception">Throw if the sub-domain does not resolve to a Tenant</exception>
        public async Task<Tenant> ResolveAsync()
        {
            var host = _httpContextAccessor.HttpContext.Request.Host.Host;

            if (host == "localhost")
            {
                return await _db.Tenants.FirstOrDefaultAsync(t => t.Code == host) ?? throw new Exception($"Tenant not found for host '{host}'");
            }

            var subdomain = GetSubdomain(host);
            var tenant = await _db.Tenants.FirstOrDefaultAsync(t => t.Code == subdomain);

            return tenant ?? throw new Exception($"Tenant not found for subdomain '{subdomain}'");
        }

        private string GetSubdomain(string host)
        {
            var parts = host.Split('.');
            if (parts.Length == 3)
            {
                return parts[0];
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
