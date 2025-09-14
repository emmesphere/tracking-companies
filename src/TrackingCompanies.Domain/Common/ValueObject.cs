namespace TrackingCompanies.Domain.Common;

public abstract class ValueObject
{
    protected abstract IEnumerable<object> GetEqualityComponents();
    public override bool Equals(object? obj)
    {
        if (obj == null || obj.GetType() != GetType()) return false;
        var other = (ValueObject)obj;
        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }
    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            foreach (var part in GetEqualityComponents())
                hash = hash * 23 + (part?.GetHashCode() ?? 0);
            return hash;
        }
    }
}