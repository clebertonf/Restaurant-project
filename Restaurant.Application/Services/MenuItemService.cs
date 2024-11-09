using Restaurant.Application.DTOS;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Services;

public class MenuItemService : IMenuItemService
{
    public Task<IEnumerable<MenuItemDto>> GetMenuItems()
    {
        throw new NotImplementedException();
    }

    public Task<MenuItemDto> GetMenuItemById(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddMenuItem(MenuItemDto menuItemDto)
    {
        throw new NotImplementedException();
    }

    public Task UpdateMenuItem(MenuItemDto menuItemDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteMenuItem(int id)
    {
        throw new NotImplementedException();
    }
}