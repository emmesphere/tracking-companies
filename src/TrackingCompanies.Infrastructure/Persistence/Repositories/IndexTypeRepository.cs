using Microsoft.EntityFrameworkCore;
using TrackingCompanies.Domain.Entities;
using TrackingCompanies.Domain.Repositories;

namespace TrackingCompanies.Infrastructure.Persistence.Repositories;

public class IndexTypeRepository(AppDbContext context) : IIndexTypeRepository
{
    private readonly AppDbContext _context = context;
    
    public async Task<IndexType?> GetByIdAsync(Guid id, 
        CancellationToken cancellationToken = default) 
        => await _context.IndexTypes.FindAsync(id);

    public async Task<IEnumerable<IndexType>> GetAllAsync(CancellationToken cancellationToken = default)
        => await _context.IndexTypes.ToListAsync(cancellationToken: cancellationToken);

    public void Add(IndexType indexType)
        => _context.IndexTypes.Add(indexType);

    public void Update(IndexType indexType)
        => _context.IndexTypes.Update(indexType);

    public void Remove(IndexType indexType)
        => _context.IndexTypes.Remove(indexType);
}