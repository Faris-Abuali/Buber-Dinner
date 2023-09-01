using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.User.ValueObjects;

public class UserId : ValueObject
{
    private UserId(Guid id)
    {
        Value = id;
    }
    
    public Guid Value { get; }
    
    public static UserId CreateUnique()
    {
        return new UserId(Guid.NewGuid());
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    public static implicit operator Guid(UserId userId)
    {
        return userId.Value;
    }
    
    public static implicit operator UserId(Guid userId)
    {
        return new(userId);
    }
}