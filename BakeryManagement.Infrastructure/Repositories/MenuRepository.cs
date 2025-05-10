using BakeryManagement.Domain.Entities;
using BakeryManagement.Domain.Interfaces;
using BakeryManagement.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BakeryManagement.Infrastructure.Repositories
{
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        public MenuRepository(AppDbContext context)
            : base(context) { }

        public async Task<IEnumerable<Menu>> GetMenuByOfficeIdAsync(int bakeryOfficeId)
        {
            return await _dbContext
                .Set<Menu>()
                .Include(m => m.Bread)
                .Where(m => m.BakeryOfficeId == bakeryOfficeId)
                .ToListAsync();
        }
    }
}
