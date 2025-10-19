using TrackingCompanies.Domain.Common;
using TrackingCompanies.Domain.Enums;

namespace TrackingCompanies.Domain.Entities;

public class IndexType : AggregateRoot<Guid>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    
    public decimal RecommendedValue { get; private set; }
    public IndexGroup IndexGroup { get; private set; }
    
    private IndexType(){ }

    private IndexType(Guid id, string name, string description, decimal recommendedValue, IndexGroup group) : base(id)
    {
        Name = name;
        Description = description;
        RecommendedValue = recommendedValue;
        IndexGroup = group;
    }

    public static IndexType CreateIndex(string name, string description, decimal recommendedValue, IndexGroup group) =>
        new IndexType(Guid.NewGuid(), name, description, recommendedValue, group);
}