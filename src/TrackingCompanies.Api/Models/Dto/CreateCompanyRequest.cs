namespace TrackingCompanies.Api.Models.Dto;

public record CreateCompanyRequest(string Name, string Ticker, int IndustrySectorId);

public record CreateCompanyResponse(Guid Id, string Name, string Ticker, int IndustrySectorId);