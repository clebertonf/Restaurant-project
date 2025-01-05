using MediatR;

namespace Restaurant.Application.CQRS.Order.Commands;

public abstract class OrderCommand : IRequest<Domain.Entities.Order>
{
    public DateTime Date { get; private set; }
    public int TableNumber { get; private set; }
    public decimal Total { get; private set; }
    public IList<Domain.Entities.MenuItem>? MenuItems { get; set; }
}