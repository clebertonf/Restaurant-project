using MediatR;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Application.CQRS.MenuItem.Commands.Handlers;

public class MenuItemCreateCommandHandler : IRequestHandler<MenuItemCreateCommand, Domain.Entities.MenuItem>
{
    private readonly IMenuItemRepository _menuItemRepository;

    public MenuItemCreateCommandHandler(IMenuItemRepository menuItemRepository)
    {
        _menuItemRepository = menuItemRepository;
    }

    public async Task<Domain.Entities.MenuItem> Handle(MenuItemCreateCommand request, CancellationToken cancellationToken)
    {
        var menuItem = new Domain.Entities.MenuItem(request.Name, request.Description, request.Price);

        if (menuItem is null)
        {
            throw new ApplicationException("MenuItem is null");
        }
        
        return await _menuItemRepository.CreateMenuItemAsync(menuItem);
    }
}