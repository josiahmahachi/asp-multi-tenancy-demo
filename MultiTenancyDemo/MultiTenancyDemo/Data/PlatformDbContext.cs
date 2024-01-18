using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MultiTenancyDemo.Contracts.Data;
using MultiTenancyDemo.Contracts.Options;

namespace MultiTenancyDemo.Data
{
    public class PlatformDbContext : DbContext
    {
        private readonly IOptions<MyAppOptions> _configuration;

        public DbSet<Tenant> Tenants { get; set; }

        public PlatformDbContext(DbContextOptions<PlatformDbContext> options, IOptions<MyAppOptions> configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>().ToTable("Tenants");
            modelBuilder.Entity<Tenant>().HasIndex(x => x.Name).IsUnique(true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var localConnection = _configuration.Value.PlatformConnectionString;

            optionsBuilder.UseSqlServer(localConnection);
        }
    }
}
