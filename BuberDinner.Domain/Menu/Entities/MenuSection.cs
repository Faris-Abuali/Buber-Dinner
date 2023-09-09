using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities;

public sealed class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem> _items = new();

    private MenuSection(
        MenuSectionId menuSectionId,
        string name,
        string description,
        List<MenuItem> items) : base(menuSectionId)
    {
        Name = name;
        Description = description;
        _items.AddRange(items);
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    public static MenuSection Create(string name, string description, List<MenuItem>? items)
    {
        return new(
            MenuSectionId.CreateUnique(), 
            name, 
            description,
            items ?? new());
    }
    
    #pragma warning disable CS8618
        private MenuSection() { } // Required for EF Core
    #pragma warning restore CS8618
}