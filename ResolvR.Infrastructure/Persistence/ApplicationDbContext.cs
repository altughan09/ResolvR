using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResolvR.Domain.Entities;
using ResolvR.Infrastructure.Persistence.EntityConfigurations;

namespace ResolvR.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Complaint> Complaints { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BrandEntityConfiguration());
        modelBuilder.ApplyConfiguration(new BranchEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ComplaintEntityConfiguration());
        
        modelBuilder.Entity<User>()
            .HasMany(o => o.OwnedComplaints)
            .WithOne(r => r.Creator)
            .HasForeignKey(r => r.CreatorId);
        
        base.OnModelCreating(modelBuilder);
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}