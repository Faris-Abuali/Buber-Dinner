using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

public class MenuItemId : ValueObject
{
    public Guid Value { get; }

    private MenuItemId(Guid id)
    {
        Value = id;
    }

    public static MenuItemId CreateUnique()
    {
        return new (Guid.NewGuid());
    }
    
    public static MenuItemId Create(Guid id)
    {
        return new (id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    #pragma warning disable CS8618
        private MenuItemId() { } // Required for EF Core
    #pragma warning restore CS8618
}