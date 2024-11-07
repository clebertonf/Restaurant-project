using Restaurant.Domain.Entities;

namespace Restaurant.Domain.Interfaces;

public interface IOrderRepository
{
    Task<List<Order>> GetAllOrdersAsync();
    Task<Order> GetOrderByIdAsync(Guid id);
    Task<Order> CreateOrderAsync(Order order);
    Task<Order> UpdateOrderAsync(Order order);
    Task RemoveOrderAsync(Order order);
}