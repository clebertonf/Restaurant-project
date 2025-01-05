using MediatR;

namespace Restaurant.Application.CQRS.Order.Commands;

public class OrderRemoveCommand : IRequest<Domain.Entities.Order>
{
    public int Id { get; set; }
    public OrderRemoveCommand(int id)
    {
        Id = id;
    }
}