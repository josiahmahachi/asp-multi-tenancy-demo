using Microsoft.EntityFrameworkCore;
using MultiTenancyDemo.Contracts.Data;

namespace MultiTenancyDemo.Data
{
    public class TenantDbContext : DbContext
    {
        private readonly string? _connectionString;

        public DbSet<Listing> Listings { get; set; }

        public TenantDbContext(DbContextOptions<TenantDbContext> options) : base(options) 
        {
            Listings = Set<Listing>();
        }

        public TenantDbContext(string connectionString) : base(CreateOptions(connectionString))
        {
            _connectionString = connectionString;
            Listings = Set<Listing>();
        }

        private static DbContextOptions CreateOptions(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TenantDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return optionsBuilder.Options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Listing>().ToTable("Listings");
        }
    }
}
