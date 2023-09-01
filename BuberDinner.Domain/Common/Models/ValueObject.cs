namespace BuberDinner.Domain.Common.Models;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract IEnumerable<object> GetEqualityComponents();

    // This implements Equatable interface
    public bool Equals(ValueObject? other)
    {
        return Equals((object?)other); // simply call the below Equals() method
    }

    // 👇 This overrides Object.Equals()
    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObject)obj;

        return GetEqualityComponents()
            .SequenceEqual(other.GetEqualityComponents());
    }
    
    public static bool operator ==(ValueObject left, ValueObject right)
    {
        return Equals(left, right); // This Equals() comes from System.Object
    }

    public static bool operator !=(ValueObject left, ValueObject right)
    {
        return !Equals(left, right); // This Equals() comes from System.Object
    }
    
    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x?.GetHashCode() ?? 0)
            .Aggregate((curr, next) => curr ^ next);
    }
}
