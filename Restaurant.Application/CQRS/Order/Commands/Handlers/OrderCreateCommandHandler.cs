using MediatR;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Application.CQRS.Order.Commands.Handlers;

public class OrderCreateCommandHandler : IRequestHandler<OrderCreateCommand, Domain.Entities.Order>
{
    private readonly IOrderRepository _orderRepository;

    public OrderCreateCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Domain.Entities.Order> Handle(OrderCreateCommand request, CancellationToken cancellationToken)
    {
        var order = new Domain.Entities.Order(request.TableNumber, request.Total);
        
        if(order is null)
            throw new ApplicationException("Order is null");

        return await _orderRepository.CreateOrderAsync(order);
    }
}