using BakeryManagement.Domain.Entities;
using BakeryManagement.Domain.Interfaces;
using BakeryManagement.Infrastructure.Database;

namespace BakeryManagement.Infrastructure.Repositories
{
    public class BreadRepository : BaseRepository<Bread>, IBreadRepository
    {
        public BreadRepository(AppDbContext context)
            : base(context) { }
    }
}
