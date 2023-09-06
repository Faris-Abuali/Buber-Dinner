using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public class DinnerId : ValueObject
{
    public Guid Value { get; }
    
    private DinnerId(Guid id)
    {
        Value = id;
    }
    
    public static DinnerId CreateUnique()
    {
        return new (Guid.NewGuid());
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}