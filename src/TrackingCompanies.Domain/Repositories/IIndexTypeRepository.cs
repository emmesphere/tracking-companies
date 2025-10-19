using TrackingCompanies.Domain.Entities;

namespace TrackingCompanies.Domain.Repositories;

public interface IIndexTypeRepository
{
    Task<IndexType?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<IndexType>> GetAllAsync(CancellationToken cancellationToken = default);
    void Add(IndexType indexType);
    void Update(IndexType indexType);
    void Remove(IndexType indexType);
}