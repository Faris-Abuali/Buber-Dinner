using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

public class MenuId : ValueObject
{
    public Guid Id { get; }

    private MenuId(Guid id)
    {
        Id = id;
    }

    public static MenuId CreateUnique()
    {
        return new MenuId(Guid.NewGuid());
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Id;
    }
}