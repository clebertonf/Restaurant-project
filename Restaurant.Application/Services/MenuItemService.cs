using AutoMapper;
using Restaurant.Application.DTOS;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Application.Services;

public class MenuItemService : IMenuItemService
{
    private readonly IMenuItemRepository _menuItemRepository;
    private readonly IMapper _mapper;

    public MenuItemService(IMenuItemRepository menuItemRepository, IMapper mapper)
    {
        _menuItemRepository = menuItemRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MenuItemDto>> GetMenuItems()
    {
        var menuItem = await _menuItemRepository.GetMenuItemsAsync();
        return _mapper.Map<IEnumerable<MenuItemDto>>(menuItem);
    }

    public async Task<MenuItemDto> GetMenuItemById(int id)
    {
        var menuItem = await _menuItemRepository.GetMenuItemByIdAsync(id);
        return _mapper.Map<MenuItemDto>(menuItem);
    }

    public async Task AddMenuItem(MenuItemDto menuItemDto)
    {
       var menuItem = _mapper.Map<MenuItem>(menuItemDto);
       await _menuItemRepository.CreateMenuItemAsync(menuItem);
    }

    public async Task UpdateMenuItem(MenuItemDto menuItemDto)
    {
        var menuItem = _mapper.Map<MenuItem>(menuItemDto);
        await _menuItemRepository.UpdateMenuItemAsync(menuItem);
    }

    public async Task DeleteMenuItem(int id)
    {
        var menuItem = await _menuItemRepository.GetMenuItemByIdAsync(id);
        await _menuItemRepository.DeleteMenuItemAsync(menuItem);
    }
}