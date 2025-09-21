using TrackingCompanies.Domain.Entities;

namespace TrackingCompanies.Domain.Repositories;

public interface IIndustrySectorRepository
{
    Task<IndustrySector?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<List<IndustrySector>> GetAllAsync(CancellationToken cancellationToken = default);
}