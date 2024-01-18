using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiTenancyDemo.Contracts.Data;

namespace MultiTenancyDemo.Data.EntityConfigurations
{
    public class ListingConfiguration : IEntityTypeConfiguration<Listing>
    {
        public void Configure(EntityTypeBuilder<Listing> builder)
        {
            builder.HasIndex(e => e.Slug).IsUnique();
        }
    }
}
