using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ResolvR.Domain.Entities;

namespace ResolvR.Infrastructure.Persistence.EntityConfigurations;

[ExcludeFromCodeCoverage]
public class ComplaintEntityConfiguration : IEntityTypeConfiguration<Complaint>
{
    public void Configure(EntityTypeBuilder<Complaint> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(t => t.Title).IsRequired().HasMaxLength(255).HasColumnType("nvarchar");
        builder.Property(t => t.Description).IsRequired().HasColumnType("nvarchar(max)");
        builder.Property(t => t.Resolution).IsRequired(false).HasColumnType("nvarchar(max)");
        builder.Property(t => t.IsResolved);
        builder.Property(t => t.CreatedAt).IsRequired().HasColumnType("datetime");
        builder.Property(t => t.UpdatedAt).IsRequired(false).HasColumnType("datetime");
        builder.Property(t => t.ResolvedAt).IsRequired(false).HasColumnType("datetime");
    }
}