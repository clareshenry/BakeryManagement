using BakeryManagement.Domain.Entities;

namespace BakeryManagement.Domain.Interfaces
{
    public interface IBreadRepository
    {
        Task<IEnumerable<Bread>> GetAllAsync();
        Task<Bread?> GetByIdAsync(int id);
        Task AddAsync(Bread bread);
        Task UpdateAsync(Bread bread);
        Task DeleteAsync(int id);
    }
}
