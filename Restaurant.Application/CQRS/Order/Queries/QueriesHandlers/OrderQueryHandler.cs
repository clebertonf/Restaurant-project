using MediatR;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Application.CQRS.Order.Queries.QueriesHandlers;

public class OrderQueryHandler: IRequestHandler<OrderQuery, IEnumerable<Domain.Entities.Order>>
{
    private readonly IOrderRepository _orderRepository;

    public OrderQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<Domain.Entities.Order>> Handle(OrderQuery request, CancellationToken cancellationToken)
    {
        return await _orderRepository.GetAllOrdersAsync();
    }
}