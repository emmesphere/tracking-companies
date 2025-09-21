using Microsoft.EntityFrameworkCore;
using TrackingCompanies.Domain.Entities;
using TrackingCompanies.Domain.Repositories;

namespace TrackingCompanies.Infrastructure.Persistence.Repositories;

public class IndustrySectorRepository:IIndustrySectorRepository
{
    private readonly AppDbContext _context;
    public IndustrySectorRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IndustrySector?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.IndustrySectors.FindAsync(id, cancellationToken);
    }

    public async Task<List<IndustrySector>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.IndustrySectors.ToListAsync();
    }
}