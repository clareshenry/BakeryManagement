using BakeryManagement.Domain.Entities;

namespace BakeryManagement.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> Create(int bakeryOfficeId);
        Task<Order?> GetOrderByBakeryOfficeId(int bakeryOfficeId);
        Task<int> GetTotalOrderItemsQuantityByBakeryOfficeIdAsync(int bakeryOfficeId);
    }
}
