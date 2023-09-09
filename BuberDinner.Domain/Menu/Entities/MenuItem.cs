using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities;

public class MenuItem : Entity<MenuItemId>
{
    public string Name { get; }
    
    public string Description { get; }

    private MenuItem(MenuItemId menuItemId, string name, string description) 
        : base(menuItemId)
    {
        Name = name;
        Description = description;
    }
    
    public static MenuItem Create(string name, string description)
    {
        return new(MenuItemId.CreateUnique(), name, description);
    }
    
    #pragma warning disable CS8618
        private MenuItem() { } // Required for EF Core
    #pragma warning restore CS8618
}