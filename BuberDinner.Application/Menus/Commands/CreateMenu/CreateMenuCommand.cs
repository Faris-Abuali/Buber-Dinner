using BuberDinner.Domain.Menu;

using MediatR;

using ErrorOr;

namespace BuberDinner.Application.Menus.Commands.CreateMenu;

public record CreateMenuCommand(
    string HostId, // this will be received from the route parameter
    string Name,
    string Description,
    List<MenuSectionCommand> Sections) : IRequest<ErrorOr<Menu>>;

public record MenuSectionCommand(
    string Name,
    string Description,
    List<MenuItemCommand> Items);

public record MenuItemCommand(
    string Name,
    string Description);