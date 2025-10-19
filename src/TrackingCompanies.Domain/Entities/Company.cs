using TrackingCompanies.Domain.Common;
using TrackingCompanies.Domain.ValueObject;

namespace TrackingCompanies.Domain.Entities;

public class Company : AggregateRoot<Guid>
{
    public Ticker Ticker { get; private set; }
    public string Name { get; private set; }
    public int IndustrySectorId { get; private set; }
    public virtual IndustrySector IndustrySector { get; private set; }
    
    private Company() { }

    private Company(Guid id, string name, Ticker ticker, int industrySectorId):base(id)
    {
        Name = name;
        Ticker = ticker;
        IndustrySectorId = industrySectorId;
    }

    public static Company CreateNew(string name, string ticker, int industrySectorId) =>
        new Company(Guid.NewGuid(), name, new Ticker(ticker), industrySectorId);
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

public class IncomeStatement : AggregateRoot<Guid>
{
    public Guid CompanyId { get; private set; }
    public virtual Company Company { get; set; }
    public decimal? NetProfit { get; set; }
    public decimal? NetIncome { get; set; }
    public decimal? NetWorth { get; set; }
    public decimal? NetDebit { get; set; }
    public decimal? StockPrice { get; set; }
    public decimal? DividendsPerShare { get; set; }
    public decimal? NumberOfShares { get; set; }
    public decimal? ROIC { get; set; }
    public decimal? WACC { get; set; }
    public DateTime CreatedAt { get; } = DateTime.Today;
    
}