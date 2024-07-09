using Microsoft.EntityFrameworkCore;
using ResolvR.Domain.Abstractions;
using ResolvR.Domain.Entities;
using ResolvR.Infrastructure.Persistence;

namespace ResolvR.Infrastructure.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BrandRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<Brand>> GetAllAsync()
    {
        var brands = await _dbContext.Set<Brand>()
            .AsNoTracking()
            .ToListAsync();
        
        return brands;
    }

    public async Task<Brand?> GetAsync(Guid id)
    {
        var brand = await _dbContext.Set<Brand>()
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == id);
        
        return brand;
    }

    public async Task AddAsync(Brand brand)
    {
        await _dbContext.Set<Brand>().AddAsync(brand);
    }

    public void Update(Brand brand)
    {
        _dbContext.Set<Brand>().Update(brand);
    }

    public void Delete(Brand brand)
    {
        _dbContext.Set<Brand>().Remove(brand);
    }
}