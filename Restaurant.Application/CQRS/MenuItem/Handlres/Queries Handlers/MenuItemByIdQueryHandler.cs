using MediatR;
using Restaurant.Application.CQRS.MenuItem.Queries;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Application.CQRS.MenuItem.Handlres.Queries_Handlers;

public class MenuItemByIdQueryHandler : IRequestHandler<MenuitemByIdQuery, Domain.Entities.MenuItem>
{
    private readonly IMenuItemRepository _menuItemRepository;

    public MenuItemByIdQueryHandler(IMenuItemRepository menuItemRepository)
    {
        _menuItemRepository = menuItemRepository;
    }
    
    public async Task<Domain.Entities.MenuItem> Handle(MenuitemByIdQuery request, CancellationToken cancellationToken)
    {
        return await _menuItemRepository.GetMenuItemByIdAsync(request.Id);
    }
}