using TrackingCompanies.Domain.Entities;

namespace TrackingCompanies.Domain.Repositories;

public interface ICompanyRepository
{
    Task<Company?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Company?> GetByTickerAsync(string ticker, CancellationToken cancellationToken = default);
    Task<IEnumerable<Company>> GetByIndustrySectorAsync(int industrySectorId, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(string ticker);
    void Add(Company company);
    void Update(Company company);
    void Remove(Company company);
}