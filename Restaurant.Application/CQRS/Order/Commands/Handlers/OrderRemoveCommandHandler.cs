using MediatR;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Application.CQRS.Order.Commands.Handlers;

public class OrderRemoveCommandHandler : IRequestHandler<OrderRemoveCommand, Domain.Entities.Order>
{
    private readonly IOrderRepository _orderRepository;

    public OrderRemoveCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Domain.Entities.Order> Handle(OrderRemoveCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetOrderByIdAsync(request.Id);
        if(order is null)
            throw new ApplicationException($"Order {request.Id} not found");
        
        return await _orderRepository.DeleteOrderAsync(order);
    }
}