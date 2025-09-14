namespace TrackingCompanies.Domain.ValueObject;

public sealed class Ticker : Common.ValueObject
{
    public string Code { get; private set; }

    public Ticker()
    {
        Code = string.Empty;
    }
    public Ticker(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("Ticker can't be empty.", nameof(code));

        var normalized = code.Trim().ToUpperInvariant();
        if (normalized.Length > 10)
            throw new ArgumentException("Ticker is too long.", nameof(code));

        Code = normalized;
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Code;
    }

    public override string ToString() => Code;
}