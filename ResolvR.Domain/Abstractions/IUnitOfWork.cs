using System.Data;

namespace ResolvR.Domain.Abstractions;

public interface IUnitOfWork
{
    IBrandRepository BrandRepository { get; }
    IBranchRepository BranchRepository { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    IDbTransaction BeginTransaction();
}