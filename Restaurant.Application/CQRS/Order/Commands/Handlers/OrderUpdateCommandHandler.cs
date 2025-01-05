using MediatR;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Application.CQRS.Order.Commands.Handlers;

public class OrderUpdateCommandHandler : IRequestHandler<OrderUpdateCommand, Domain.Entities.Order>
{
    private readonly IOrderRepository _orderRepository;

    public OrderUpdateCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Domain.Entities.Order> Handle(OrderUpdateCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetOrderByIdAsync(request.Id);
        if(order is null)
            throw new ApplicationException($"Order with id: {request.Id} not found");
        
        var newOrder = new Domain.Entities.Order(request.TableNumber, request.Total);
        return await _orderRepository.UpdateOrderAsync(newOrder);
    }
}