using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Interfaces;

public interface IMenuItemRepository
{
    Task<List<MenuItem>> GetMenuItemsAsync();
    Task<MenuItem> GetMenuItemByIdAsync(int id);
    Task<MenuItem> CreateMenuItemAsync(MenuItem menuItem);
    Task<MenuItem> UpdateMenuItemAsync(MenuItem menuItem);
    Task<MenuItem> DeleteMenuItemAsync(MenuItem menuItem);
}