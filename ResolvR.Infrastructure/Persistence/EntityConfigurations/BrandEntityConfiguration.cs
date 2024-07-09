using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResolvR.Domain.Entities;
using ResolvR.Infrastructure.Persistence.SeedData;

namespace ResolvR.Infrastructure.Persistence.EntityConfigurations;

public class BrandEntityConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(t => t.Name).IsRequired().HasMaxLength(255).HasColumnType("nvarchar");
        builder.Property(t => t.Description).IsRequired(false).HasColumnType("nvarchar(max)");
        builder.Property(t => t.LogoUrl).IsRequired(false).HasColumnType("nvarchar(max)");
        builder.Property(t => t.WebsiteUrl).IsRequired(false).HasColumnType("nvarchar(max)");
        builder.Property(t => t.CreatedAt).IsRequired().HasColumnType("datetime");

        builder.HasMany(t => t.Branches)
            .WithOne()
            .HasForeignKey(b => b.BrandId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasData(BrandSeedData.GetBrandsList());
    }
}