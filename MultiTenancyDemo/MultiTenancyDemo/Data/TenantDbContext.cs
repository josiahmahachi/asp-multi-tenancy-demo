using Microsoft.EntityFrameworkCore;
using MultiTenancyDemo.Contracts.Data;

namespace MultiTenancyDemo.Data
{
    public class TenantDbContext : DbContext
    {
        public DbSet<Listing> Listings { get; set; }

        public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Listing).Assembly);
        }
    }
}
