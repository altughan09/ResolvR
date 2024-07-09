using System.Data;
using Microsoft.EntityFrameworkCore.Storage;
using ResolvR.Domain.Abstractions;
using ResolvR.Infrastructure.Persistence;

namespace ResolvR.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        BrandRepository = new BrandRepository(_context);
    }
    
    public IBrandRepository BrandRepository { get; }
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public IDbTransaction BeginTransaction()
    {
        var transaction = _context.Database.BeginTransaction();
        return transaction.GetDbTransaction();
    }
}