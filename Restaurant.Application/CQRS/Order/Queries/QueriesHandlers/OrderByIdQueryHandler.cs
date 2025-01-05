using MediatR;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Application.CQRS.Order.Queries.QueriesHandlers;

public class OrderByIdQueryHandler : IRequestHandler<OrderByIdQuery, Domain.Entities.Order>
{
    private readonly IOrderRepository _orderRepository;

    public OrderByIdQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Domain.Entities.Order> Handle(OrderByIdQuery request, CancellationToken cancellationToken)
    {
        return await _orderRepository.GetOrderByIdAsync(request.Id);
    }
}