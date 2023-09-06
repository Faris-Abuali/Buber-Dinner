using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

public class MenuId : ValueObject
{
    public Guid Value { get; }

    private MenuId(Guid id)
    {
        Value = id;
    }

    public static MenuId CreateUnique()
    {
        return new MenuId(Guid.NewGuid());
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}