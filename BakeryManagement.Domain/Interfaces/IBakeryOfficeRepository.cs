using BakeryManagement.Domain.Entities;

namespace BakeryManagement.Domain.Interfaces
{
    public interface IBakeryOfficeRepository : IRepository<BakeryOffice>
    {
        Task SetAllOrdersInactive(int bakeryOfficeId);
    }
}
