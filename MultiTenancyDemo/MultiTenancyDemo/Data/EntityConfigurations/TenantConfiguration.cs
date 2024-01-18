using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenancyDemo.Contracts.Data;

namespace MultiTenancyDemo.Data.EntityConfigurations
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasIndex(e => e.Name).IsUnique();
        }
    }
}
