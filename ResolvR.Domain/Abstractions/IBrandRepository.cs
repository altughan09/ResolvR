using ResolvR.Domain.Entities;

namespace ResolvR.Domain.Abstractions;

public interface IBrandRepository
{
    Task<IEnumerable<Brand>> GetAllAsync();
    Task<Brand?> GetAsync(Guid id);
    Task AddAsync(Brand brand);
    void Update(Brand brand);
    void Delete(Brand brand);
}