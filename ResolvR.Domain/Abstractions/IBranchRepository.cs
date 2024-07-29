using ResolvR.Domain.Entities;

namespace ResolvR.Domain.Abstractions;

public interface IBranchRepository
{
    Task<IEnumerable<Branch>> GetAllAsync();
    Task<Branch?> GetAsync(Guid id);
    Task AddAsync(Branch branch);
    void Update(Branch branch);
    void Delete(Branch branch);
}