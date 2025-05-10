using BakeryManagement.Domain.Entities;
using BakeryManagement.Domain.Interfaces;
using BakeryManagement.Infrastructure.Database;

namespace BakeryManagement.Infrastructure.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(AppDbContext context)
            : base(context) { }
    }
}
