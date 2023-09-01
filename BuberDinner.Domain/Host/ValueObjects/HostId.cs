using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Host.ValueObjects;

public class HostId : ValueObject
{
    public Guid Id { get; }
    
    private HostId(Guid id)
    {
        Id = id;
    }
    
    public static HostId CreateUnique()
    {
        return new (Guid.NewGuid());
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}