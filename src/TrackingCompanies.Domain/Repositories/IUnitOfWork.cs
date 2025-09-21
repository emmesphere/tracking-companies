namespace TrackingCompanies.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    ICompanyRepository Companies { get; }
    IIndustrySectorRepository IndustrySectors { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<bool> SaveChangesWithTransactionAsync(CancellationToken cancellationToken = default);
}