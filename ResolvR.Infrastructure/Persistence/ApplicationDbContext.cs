using Microsoft.EntityFrameworkCore;
using ResolvR.Domain.Entities;
using ResolvR.Infrastructure.Persistence.EntityConfigurations;

namespace ResolvR.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Complaint> Complaints { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BrandEntityConfiguration());
        modelBuilder.ApplyConfiguration(new BranchEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ComplaintEntityConfiguration());
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}