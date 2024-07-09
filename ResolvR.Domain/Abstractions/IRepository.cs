namespace ResolvR.Domain.Abstractions;

public interface IRepository<TEntity, in TKey>
{
    Task<TEntity> GetAsync(TKey id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}