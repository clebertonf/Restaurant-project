using Restaurant.Application.DTOS;

namespace Restaurant.Application.Interfaces;

public interface IMenuItemService
{
    Task<IEnumerable<MenuItemDto>> GetMenuItems();
    Task<MenuItemDto> GetMenuItemById(int id);
    Task AddMenuItem(MenuItemDto menuItemDto);
    Task UpdateMenuItem(MenuItemDto menuItemDto);
    Task DeleteMenuItem(int id);
}