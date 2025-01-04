using MediatR;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Application.CQRS.MenuItem.Commands.Handlers;

public class MenuItemRemoveCommandHandler :  IRequestHandler<MenuItemRemoveCommand, Domain.Entities.MenuItem>
{
    private readonly IMenuItemRepository _menuItemRepository;

    public MenuItemRemoveCommandHandler(IMenuItemRepository menuItemRepository)
    {
        _menuItemRepository = menuItemRepository;
    }

    public async Task<Domain.Entities.MenuItem> Handle(MenuItemRemoveCommand request, CancellationToken cancellationToken)
    {
        var menuItem = await _menuItemRepository.GetMenuItemByIdAsync(request.Id);

        if (menuItem is null)
        {
            throw new ApplicationException("MenuItem not found");
        }
        
        var result = await _menuItemRepository.DeleteMenuItemAsync(menuItem);
        return result;
    }
}