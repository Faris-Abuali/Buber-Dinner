using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Dinner.ValueObjects;

public class DinnerId : ValueObject
{
    public Guid Id { get; }
    
    private DinnerId(Guid id)
    {
        Id = id;
    }
    
    public static DinnerId CreateUnique()
    {
        return new (Guid.NewGuid());
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}