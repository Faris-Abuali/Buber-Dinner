using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Menu;

namespace BuberDinner.Infrastructure.Persistence;

public class MenuRepository : IMenuRepository
{    
    private static readonly List<Menu> Menus = new();
    // static naming convention is `Menus` not `_menus

    public void Add(Menu menu)
    {
        Menus.Add(menu);
    }
}