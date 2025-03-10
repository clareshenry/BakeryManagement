using BakeryManagement.Domain.Entities;
using BakeryManagement.Domain.Interfaces;
using BakeryManagement.Infrastructure.Database;

namespace BakeryManagement.Infrastructure.Repositories
{
    public class IngredientRepository : BaseRepository<Ingredient>, IIngredientRepository
    {
        public IngredientRepository(AppDbContext context)
            : base(context) { }
    }
}
