using MediatR;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Application.CQRS.MenuItem.Queries.Handlers;

public class MenuItemQueryHandler : IRequestHandler<MenuItemQuery, IEnumerable<Domain.Entities.MenuItem>>
{
    private readonly IMenuItemRepository _menuItemRepository;

    public MenuItemQueryHandler(IMenuItemRepository menuItemRepository)
    {
        _menuItemRepository = menuItemRepository;
    }

    public async Task<IEnumerable<Domain.Entities.MenuItem>> Handle(MenuItemQuery request, CancellationToken cancellationToken)
    {
        return await _menuItemRepository.GetMenuItemsAsync();
    }
}