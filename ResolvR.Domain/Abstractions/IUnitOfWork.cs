using System.Data;

namespace ResolvR.Domain.Abstractions;

public interface IUnitOfWork
{
    IBrandRepository BrandRepository { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    IDbTransaction BeginTransaction();
}