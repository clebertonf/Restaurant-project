using AutoMapper;
using MediatR;
using Restaurant.Application.CQRS.MenuItem.Commands;
using Restaurant.Application.CQRS.MenuItem.Queries;
using Restaurant.Application.DTOS;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Services;

public class MenuItemService : IMenuItemService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public MenuItemService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MenuItemDto>> GetMenuItems()
    {
        var menuItemQuery = new MenuItemQuery();
        if(menuItemQuery is null)
            throw new ArgumentNullException(nameof(menuItemQuery));
        
        var menuItems = await _mediator.Send(menuItemQuery);
        return _mapper.Map<IEnumerable<MenuItemDto>>(menuItems);
    }

    public async Task<MenuItemDto> GetMenuItemById(int id)
    {
       var menuItemQuery = new MenuItemByIdQuery(id);
       if (menuItemQuery is null)
           throw new ArgumentNullException(nameof(menuItemQuery));
       
       var menuItem = await _mediator.Send(menuItemQuery);
       return _mapper.Map<MenuItemDto>(menuItem);
    }

    public async Task AddMenuItem(MenuItemDto menuItemDto)
    {
       var menuItem = _mapper.Map<MenuItemCreateCommand>(menuItemDto);
       await _mediator.Send(menuItem);
    }

    public async Task UpdateMenuItem(MenuItemDto menuItemDto)
    {
        var menuItem = _mapper.Map<MenuItemUpdateCommand>(menuItemDto);
        await _mediator.Send(menuItem);
    }

    public async Task DeleteMenuItem(int? id)
    {
       var menuItemQuery = new MenuItemByIdQuery(id.Value);
       if (menuItemQuery is null)
           throw new ArgumentNullException(nameof(menuItemQuery));
       
       await _mediator.Send(menuItemQuery);
    }
}