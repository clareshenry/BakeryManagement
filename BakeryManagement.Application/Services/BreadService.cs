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

        public async Task<Bread?> GetBreadById(int id)
        {
            return await _breadRepository.GetByIdAsync(id);
        }
    }
}
