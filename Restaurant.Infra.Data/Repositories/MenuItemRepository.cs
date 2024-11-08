using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces;
using Restaurant.Infra.Data.Context;

namespace Restaurant.Infra.Data.Repositories;

public class MenuItemRepository : IMenuItemRepository
{
    private readonly ApplicationDbContext _context;

    public MenuItemRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<MenuItem>> GetMenuItemsAsync()
    {
        return await _context.MenuItems.ToListAsync();
    }

    public async Task<MenuItem> GetMenuItemByIdAsync(int menuItemId)
    {
        return await _context.MenuItems.FindAsync(menuItemId);
    }

    public async Task<MenuItem> CreateMenuItemAsync(MenuItem menuItem)
    {
       await _context.MenuItems.AddAsync(menuItem);
       await _context.SaveChangesAsync();
       return menuItem;
    }

    public async Task<MenuItem> UpdateMenuItemAsync(MenuItem menuItem)
    {
      _context.MenuItems.Update(menuItem);
      await _context.SaveChangesAsync();
      return menuItem;
    }
    
    public async Task<MenuItem> DeleteMenuItemAsync(MenuItem menuItem)
    {
        _context.MenuItems.Remove(menuItem);
        await _context.SaveChangesAsync();
        return menuItem;
    }
}