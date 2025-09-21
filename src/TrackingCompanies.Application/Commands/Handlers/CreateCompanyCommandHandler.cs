using TrackingCompanies.Application.Dispatcher;
using TrackingCompanies.Domain.Entities;
using TrackingCompanies.Domain.Repositories;

namespace TrackingCompanies.Application.Commands.Handlers;

public class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCompanyCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Guid> Handle(CreateCompanyCommand command, CancellationToken cancellationToken = default)
    {
        if (await _unitOfWork.Companies.ExistsAsync(ticker: command.Ticker))
            throw new InvalidOperationException($"Company already exists: {command.Ticker}");
        
        var company = Company.CreateNew(command.Name,command.Ticker,command.IndustrySectorId);
        _unitOfWork.Companies.Add(company);
        await _unitOfWork.SaveChangesAsync();
        return company.Id;
    }
}