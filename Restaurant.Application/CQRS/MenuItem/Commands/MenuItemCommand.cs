using MediatR;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.CQRS.MenuItem.Commands;

public abstract class MenuItemCommand :IRequest<Domain.Entities.MenuItem>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public bool Available { get; set; } = default;
    public Order? Order { get; set; }
}