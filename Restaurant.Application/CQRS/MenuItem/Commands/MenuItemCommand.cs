using MediatR;

namespace Restaurant.Application.CQRS.MenuItem.Commands;

public abstract class MenuItemCommand :IRequest<Domain.Entities.MenuItem>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public bool Available { get; set; }
    public Domain.Entities.Order? Order { get; set; }
}