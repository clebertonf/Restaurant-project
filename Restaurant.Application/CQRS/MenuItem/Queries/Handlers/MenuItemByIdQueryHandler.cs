using MediatR;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Application.CQRS.MenuItem.Queries.Handlers;

public class MenuItemByIdQueryHandler : IRequestHandler<MenuItemByIdQuery, Domain.Entities.MenuItem>
{
    private readonly IMenuItemRepository _menuItemRepository;

    public MenuItemByIdQueryHandler(IMenuItemRepository menuItemRepository)
    {
        _menuItemRepository = menuItemRepository;
    }
    
    public async Task<Domain.Entities.MenuItem> Handle(MenuItemByIdQuery request, CancellationToken cancellationToken)
    {
        return await _menuItemRepository.GetMenuItemByIdAsync(request.Id);
    }
}