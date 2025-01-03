using AutoMapper;
using Restaurant.Application.DTOS;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Entities;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
    {
        var order = await _orderRepository.GetAllOrdersAsync();
        return _mapper.Map<IEnumerable<OrderDto>>(order);
    }

    public async Task<OrderDto> GetOrderByIdAsync(int id)
    {
        var order = await _orderRepository.GetOrderByIdAsync(id);
        return _mapper.Map<OrderDto>(order);
    }

    public async Task AddOrderAsync(OrderDto order)
    {
        var orderEntity = _mapper.Map<Order>(order);
        await _orderRepository.CreateOrderAsync(orderEntity);
    }

    public async Task UpdateOrderAsync(OrderDto order)
    {
        var orderEntity = _mapper.Map<Order>(order);
        await _orderRepository.UpdateOrderAsync(orderEntity);
    }

    public async Task DeleteOrderAsync(int id)
    {
       var order = await _orderRepository.GetOrderByIdAsync(id);
       await _orderRepository.DeleteOrderAsync(order);
    }
}