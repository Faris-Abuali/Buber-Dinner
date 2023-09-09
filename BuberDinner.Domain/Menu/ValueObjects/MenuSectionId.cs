using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.ValueObjects;

public class MenuSectionId : ValueObject
{
    public Guid Value { get; private set; }

    private MenuSectionId(Guid id)
    {
        Value = id;
    }

    public static MenuSectionId CreateUnique()
    {
        return new (Guid.NewGuid());
    }
    
    public static MenuSectionId Create(Guid id)
    {
        return new (id);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
    
    #pragma warning disable CS8618
        private MenuSectionId() { } // Required for EF Core
    #pragma warning restore CS8618
}