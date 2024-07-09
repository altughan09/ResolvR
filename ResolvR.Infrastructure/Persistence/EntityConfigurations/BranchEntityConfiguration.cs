using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResolvR.Domain.Entities;

namespace ResolvR.Infrastructure.Persistence.EntityConfigurations;

public class BranchEntityConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(t => t.Name).IsRequired(false).HasMaxLength(255).HasColumnType("nvarchar");
        builder.Property(t => t.Email).IsRequired(false).HasMaxLength(100).HasColumnType("varchar");
        builder.Property(t => t.PhoneNumber).IsRequired(false).HasMaxLength(50).HasColumnType("varchar");
        builder.Property(t => t.CreatedAt).IsRequired().HasColumnType("datetime");

        builder.OwnsOne(x => x.Address);

        builder.HasMany(t => t.Complaints)
            .WithOne()
            .HasForeignKey(c => c.BranchId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}