using TrackingCompanies.Domain.Common;

namespace TrackingCompanies.Domain.Entities;

public class IndustrySector : AggregateRoot<int>
{
    private IndustrySector() { }

    private IndustrySector(int id, string name, string description) : base(id)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null.", nameof(name));
        
        Name = name;
        Description = description;
    }

    public static IndustrySector CreateIndustrySector(int id, string name, string description) =>
        new IndustrySector(id, name, description);
    public string Name { get; private set; }
    public string? Description { get; private set; }
}