using BakeryManagement.Domain.Entities;
using BakeryManagement.Domain.Interfaces;

namespace BakeryManagement.Application.Services
{
    public class MenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IEnumerable<Menu>> GetMenuByOfficeId(int bakeryOfficeId)
        {
            return await _menuRepository.GetMenuByOfficeIdAsync(bakeryOfficeId);
        }
    }
}
