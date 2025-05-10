using BakeryManagement.Domain.Entities;
using BakeryManagement.Domain.Interfaces;

namespace BakeryManagement.Application.Services
{
    public class BakeryOfficeService
    {
        private readonly IBakeryOfficeRepository _bakeryOfficeRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;

        public BakeryOfficeService(
            IBakeryOfficeRepository bakeryOfficeRepository,
            IOrderRepository orderRepository,
            IOrderItemRepository orderItemRepository
        )
        {
            _bakeryOfficeRepository = bakeryOfficeRepository;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }

        public async Task<IEnumerable<BakeryOffice>> GetAllAsync()
        {
            return await _bakeryOfficeRepository.GetAllAsync();
        }

        public async Task<BakeryOffice?> GetByIdAsync(int id)
        {
            return await _bakeryOfficeRepository.GetByIdAsync(id);
        }

        public async Task<int> GetTotalOrderItemsQuantityByBakeryOfficeIdAsync(int bakeryOfficeId)
        {
            return await _orderRepository.GetTotalOrderItemsQuantityByBakeryOfficeIdAsync(
                bakeryOfficeId
            );
        }

        public async Task AddOrder(int bakeryOfficeId, int breadId, int quantity)
        {
            var order = await _orderRepository.GetOrderByBakeryOfficeId(bakeryOfficeId);
            if (order == null)
            {
                order = await _orderRepository.Create(bakeryOfficeId);
            }
            await _orderItemRepository.AddAsync(new OrderItem(order.Id, breadId, quantity));
        }

        public async Task PrepareAllOrders(int id)
        {
            await _bakeryOfficeRepository.SetAllOrdersInactive(id);
        }

        public async Task<
            IEnumerable<(BakeryOffice BakeryOffice, int TotalOrders, double TotalEarnings)>
        > GetTotalOrdersAndEarningsByBakeryOfficeAsync()
        {
            var results =
                new List<(BakeryOffice BakeryOffice, int TotalOrders, double TotalEarnings)>();

            var bakeryOffices = await _bakeryOfficeRepository.GetAllWithInactiveOrdersAsync();

            foreach (var bakeryOffice in bakeryOffices)
            {
                var totalOrders = bakeryOffice.Orders.Count();
                var totalEarnings = bakeryOffice.Orders.Sum(order =>
                    order.OrderItems.Sum(oi => oi.Quantity * oi.Bread.Price)
                );

                results.Add((bakeryOffice, totalOrders, totalEarnings));
            }

            return results;
        }
    }
}
