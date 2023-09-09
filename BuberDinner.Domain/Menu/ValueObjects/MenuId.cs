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

    public static MenuId Create(Guid id)
    {
        return new MenuId(id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #pragma warning disable CS8618
        private MenuId() { } // Required for EF Core
    #pragma warning restore CS8618
}