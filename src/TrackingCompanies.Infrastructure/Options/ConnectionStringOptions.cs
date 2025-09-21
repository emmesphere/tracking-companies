namespace TrackingCompanies.Infrastructure.Options;

public class ConnectionStringsOptions
{
    public const string SectionName = "ConnectionStrings";
    
    public required string DefaultConnection { get; set; } = string.Empty;
}