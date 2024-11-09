using Restaurant.Application.DTOS;

namespace Restaurant.Application.Interfaces;

public interface IOrderService
{
    Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
    Task<OrderDto> GetOrderByIdAsync(int id);
    Task AddOrderAsync(OrderDto order);
    Task UpdateOrderAsync(OrderDto order);
    Task DeleteOrderAsync(int id);
}