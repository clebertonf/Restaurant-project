using MediatR;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Application.CQRS.MenuItem.Commands.Handlers;

public class MenItemUpdateCommandHandler : IRequestHandler<MenuItemUpdateCommand, Domain.Entities.MenuItem>
{
    private readonly IMenuItemRepository _menuItemRepository;

    public MenItemUpdateCommandHandler(IMenuItemRepository menuItemRepository)
    {
        _menuItemRepository = menuItemRepository;
    }

    public async Task<Domain.Entities.MenuItem> Handle(MenuItemUpdateCommand request, CancellationToken cancellationToken)
    {
        var menuItem = await _menuItemRepository.GetMenuItemByIdAsync(request.Id);

        if (menuItem is null)
        {
            throw new ApplicationException("MenuItem not found");
        }
        
        var newMenuItem = new Domain.Entities.MenuItem(request.Name, menuItem.Name, menuItem.Price);
        return await _menuItemRepository.UpdateMenuItemAsync(newMenuItem);
    }
}