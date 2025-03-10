using BakeryManagement.Domain.Common.Constants;
using BakeryManagement.Domain.Entities;
using BakeryManagement.Domain.Interfaces;
using BakeryManagement.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BakeryManagement.Infrastructure.Repositories
{
    public class BakeryOfficeRepository : BaseRepository<BakeryOffice>, IBakeryOfficeRepository
    {
        public BakeryOfficeRepository(AppDbContext context)
            : base(context) { }

        public async Task SetAllOrdersInactive(int bakeryOfficeId)
        {
            var bakeryOffice = await GetByIdAsync(bakeryOfficeId);
            if (bakeryOffice != null)
            {
                foreach (var order in bakeryOffice.Orders)
                {
                    order.Status = EnumStatus.INACTIVE.ToString();
                    foreach (var orderItem in order.OrderItems)
                    {
                        orderItem.Status = EnumStatus.INACTIVE.ToString();
                    }
                }

                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("BakeryOffice not found");
            }
        }

        async Task<Order?> GetOrderByBakeryOfficeId(int bakeryOfficeId)
        {
            return await _dbContext
                .Set<Order>()
                .FirstOrDefaultAsync(o =>
                    o.BakeryOfficeId == bakeryOfficeId && o.Status == EnumStatus.ACTIVE.ToString()
                );
        }
    }
}
