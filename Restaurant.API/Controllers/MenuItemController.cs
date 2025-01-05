using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.DTOS;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Entities;

namespace Restaurant.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MenuItemController : ControllerBase
{
    private readonly IMenuItemService _menuItemService;

    public MenuItemController(IMenuItemService menuItemService)
    {
        _menuItemService = menuItemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _menuItemService.GetMenuItems();
        return Ok(items);
    }

    [HttpGet("{id:int}", Name = "GetMenuItem")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _menuItemService.GetMenuItemById(id);
        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MenuItemDto item)
    {
        if (item is null)
            return BadRequest();
        await _menuItemService.AddMenuItem(item);
        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }
}