using TrackingCompanies.Domain.Common;
using TrackingCompanies.Domain.ValueObject;

namespace TrackingCompanies.Domain.Entities;

public class Company : AggregateRoot<Guid>
{
    public Ticker Ticker { get; private set; }
    public string Name { get; private set; }
    public InvestmentType Type { get; private set; }
    public int IndustrySectorId { get; private set; }
    public IndustrySector IndustrySector { get; private set; }
    
    private Company() { }

    private Company(Guid id, string name, Ticker ticker, InvestmentType type, int industrySectorId):base(id)
    {
        Name = name;
        Ticker = ticker;
        Type = type;
        IndustrySectorId = industrySectorId;
    }

    public static Company CreateNew(string name, string ticker, InvestmentType type, int industrySectorId) =>
        new Company(Guid.NewGuid(), name, new Ticker(ticker), type, industrySectorId);
    public void ChangeTicker(string newTicker)
    {
        Ticker = new Ticker(newTicker);
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid name.", nameof(name));
        Name = name.Trim();
    }

    public void AssignSector(int sectorId)
    {
        IndustrySectorId = sectorId;
    }
}