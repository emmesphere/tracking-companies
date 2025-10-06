using Microsoft.EntityFrameworkCore;
using TrackingCompanies.Domain.Entities;
using TrackingCompanies.Domain.Repositories;

namespace TrackingCompanies.Infrastructure.Persistence.Repositories;

public class CompanyRepository(AppDbContext context) : ICompanyRepository
{
    private readonly AppDbContext _context = context;
    public async Task<Company?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Companies
            .Include(c => c.IndustrySector)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task<Company?> GetByTickerAsync(string ticker, CancellationToken cancellationToken = default)
    {
        return await _context.Companies.FirstOrDefaultAsync(c => c.Ticker.Code == ticker, cancellationToken: cancellationToken);
    }

    public async Task<IEnumerable<Company>> GetByIndustrySectorAsync(int industrySectorId, CancellationToken cancellationToken = default)
    {
        return await _context.Companies.Include(c => c.IndustrySector)
            .Where(c => c.IndustrySectorId == industrySectorId)
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> ExistsAsync(string ticker)
    {
        return await _context.Companies.AnyAsync(c => c.Ticker.Code == ticker);
    }

    public void Add(Company company)
    {
        _context.Companies.Add(company);
    }

    public void Update(Company company)
    {
        _context.Companies.Update(company);
    }

    public void Remove(Company company)
    {
        _context.Companies.Remove(company);
    }
}