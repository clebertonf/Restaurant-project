using AutoMapper;
using MediatR;
using Restaurant.Application.CQRS.Order.Commands;
using Restaurant.Application.CQRS.Order.Queries;
using Restaurant.Application.DTOS;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Services;

public class OrderService : IOrderService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public OrderService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
    {
        var order = new OrderQuery();
        if(order is null)
            throw new NullReferenceException(nameof(order));
        
        var orders = await _mediator.Send(order);
        return _mapper.Map<IEnumerable<OrderDto>>(orders);
    }

    public async Task<OrderDto> GetOrderByIdAsync(int id)
    {
        var orderById = new OrderByIdQuery();
        if (orderById is null)
            throw new NullReferenceException(nameof(orderById));
        
        var order = await _mediator.Send(orderById);
        return _mapper.Map<OrderDto>(order);
    }

    public async Task AddOrderAsync(OrderDto order)
    {
        var orderEntity = _mapper.Map<OrderCreateCommand>(order);
        await _mediator.Send(orderEntity);
    }

    public async Task UpdateOrderAsync(OrderDto order)
    {
        var orderEntity = _mapper.Map<OrderUpdateCommand>(order);
        await _mediator.Send(orderEntity);
    }

    public async Task DeleteOrderAsync(int id)
    {
       var orderEntity = new OrderByIdQuery();
       if (orderEntity is null)
           throw new NullReferenceException(nameof(orderEntity));
       
       await _mediator.Send(orderEntity);
    }
}