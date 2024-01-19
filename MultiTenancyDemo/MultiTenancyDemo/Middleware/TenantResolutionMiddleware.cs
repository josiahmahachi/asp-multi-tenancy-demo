using MultiTenancyDemo.Contracts.Resolvers;
using System.Text.RegularExpressions;

namespace MultiTenancyDemo.Middleware
{
    public class TenantResolutionMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantResolutionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ITenantResolver tenantResolver)
        {
            try
            {
                if (!context.Items.ContainsKey("ConnectionString"))
                {
                    var tenant = await tenantResolver.ResolveAsync();

                    if (tenant != null)
                    {
                        var connectionString = tenant.ConnectionString;

                        context.Items["ConnectionString"] = Regex.Unescape(connectionString);
                    }
                }

                await _next(context);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
