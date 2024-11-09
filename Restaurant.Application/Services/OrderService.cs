using Restaurant.Application.DTOS;
using Restaurant.Application.Interfaces;

namespace Restaurant.Application.Services;

public class OrderService : IOrderService
{
    public Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<OrderDto> GetOrderByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddOrderAsync(OrderDto order)
    {
        throw new NotImplementedException();
    }

    public Task UpdateOrderAsync(OrderDto order)
    {
        throw new NotImplementedException();
    }

    public Task DeleteOrderAsync(int id)
    {
        throw new NotImplementedException();
    }
}