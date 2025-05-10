using BakeryManagement.Domain.Common.Constants;
using BakeryManagement.Domain.Entities;
using BakeryManagement.Domain.Interfaces;
using BakeryManagement.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BakeryManagement.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context)
            : base(context) { }

        public async Task<Order?> GetOrderByBakeryOfficeId(int bakeryOfficeId)
        {
            return await _dbContext
                .Set<Order>()
                .FirstOrDefaultAsync(o =>
                    o.BakeryOfficeId == bakeryOfficeId && o.Status == EnumStatus.ACTIVE.ToString()
                );
        }

        public async Task<Order> Create(int bakeryOfficeId)
        {
            var order = new Order(bakeryOfficeId);
            await _dbContext.Set<Order>().AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<int> GetTotalOrderItemsQuantityByBakeryOfficeIdAsync(int bakeryOfficeId)
        {
            return await _dbContext
                .Set<Order>()
                .Where(o =>
                    o.BakeryOfficeId == bakeryOfficeId && o.Status == EnumStatus.ACTIVE.ToString()
                )
                .SelectMany(o => o.OrderItems)
                .Where(oi => oi.Status == EnumStatus.ACTIVE.ToString())
                .SumAsync(oi => oi.Quantity);
        }
    }
}
