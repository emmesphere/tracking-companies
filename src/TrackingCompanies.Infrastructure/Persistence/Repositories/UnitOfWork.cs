using TrackingCompanies.Domain.Repositories;

namespace TrackingCompanies.Infrastructure.Persistence.Repositories;
public class UnitOfWork : IUnitOfWork
{
    public ICompanyRepository Companies { get; }
    public IIndustrySectorRepository IndustrySectors { get; }
    public IIndexTypeRepository IndexTypes { get; }
    
    private readonly AppDbContext _context;
    private bool _disposed = false;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Companies = new CompanyRepository(_context);
        IndustrySectors = new IndustrySectorRepository(_context);
        IndexTypes = new IndexTypeRepository(_context);
    }
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> SaveChangesWithTransactionAsync(CancellationToken cancellationToken = default)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        
        try
        {
            var result = await _context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}