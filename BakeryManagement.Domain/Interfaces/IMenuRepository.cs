using BakeryManagement.Domain.Entities;

namespace BakeryManagement.Domain.Interfaces
{
    public interface IMenuRepository : IRepository<Menu>
    {
        Task<IEnumerable<Menu>> GetMenuByOfficeIdAsync(int bakeryOfficeId);
    }
}
