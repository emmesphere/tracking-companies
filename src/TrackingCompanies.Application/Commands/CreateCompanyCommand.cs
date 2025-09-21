using TrackingCompanies.Application.Dispatcher;

namespace TrackingCompanies.Application.Commands;

public record CreateCompanyCommand(string Name, string Ticker, int IndustrySectorId) : ICommand<Guid>;