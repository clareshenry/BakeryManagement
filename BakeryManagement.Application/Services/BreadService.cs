using BakeryManagement.Domain.Entities;
using BakeryManagement.Domain.Interfaces;

namespace BakeryManagement.Application.Services
{
    public class BreadService
    {
        private readonly IBreadRepository _breadRepository;

        public BreadService(IBreadRepository breadRepository)
        {
            _breadRepository = breadRepository;
        }

        public async Task<IEnumerable<Bread>> GetAllBreadsAsync()
        {
            return await _breadRepository.GetAllAsync();
        }

        public async Task<Bread?> GetBreadByIdAsync(int id)
        {
            return await _breadRepository.GetByIdAsync(id);
        }

        public async Task AddBreadAsync(Bread bread)
        {
            await _breadRepository.AddAsync(bread);
        }

        public async Task UpdateBreadAsync(Bread bread)
        {
            await _breadRepository.UpdateAsync(bread);
        }

        public async Task DeleteBreadAsync(int id)
        {
            await _breadRepository.DeleteAsync(id);
        }
    }
}
