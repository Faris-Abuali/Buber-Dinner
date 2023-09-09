using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Host.ValueObjects;

public class HostId : ValueObject
{
    public Guid Value { get; }
    
    private HostId(Guid id)
    {
        Value = id;
    }
    
    public static HostId Create(Guid id)
    {
        return new (id);
    }
    
    public static HostId CreateUnique()
    {
        return new (Guid.NewGuid());
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    public static implicit operator Guid(HostId hostId)
    {
        return hostId.Value;
    }
    
    public static implicit operator HostId(Guid hostId)
    {
        return new (hostId);
    }
    
    #pragma warning disable CS8618
        private HostId() { } // Required for EF Core
    #pragma warning restore CS8618
}