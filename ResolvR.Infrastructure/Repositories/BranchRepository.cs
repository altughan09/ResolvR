using Microsoft.EntityFrameworkCore;
using ResolvR.Domain.Abstractions;
using ResolvR.Domain.Entities;
using ResolvR.Infrastructure.Persistence;

namespace ResolvR.Infrastructure.Repositories;

public class BranchRepository : IBranchRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BranchRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<Branch>> GetAllAsync()
    {
        var branches = await _dbContext.Set<Branch>()
            .AsNoTracking()
            .ToListAsync();

        return branches;
    }

    public async Task<Branch?> GetAsync(Guid id)
    {
        var branch = await _dbContext.Set<Branch>()
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == id);

        return branch;
    }

    public async Task AddAsync(Branch branch)
    {
        await _dbContext.Set<Branch>().AddAsync(branch);
    }

    public void Update(Branch branch)
    {
        _dbContext.Set<Branch>().Update(branch);
    }

    public void Delete(Branch branch)
    {
        _dbContext.Set<Branch>().Remove(branch);
    }
}