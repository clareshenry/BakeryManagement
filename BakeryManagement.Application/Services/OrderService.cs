using BakeryManagement.Domain.Entities;
using BakeryManagement.Domain.Interfaces;

namespace BakeryManagement.Application.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task AddOrder(Order order)
        {
            await _orderRepository.AddAsync(order);
        }
    }
}
