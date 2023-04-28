using IsTakip.Core.Classes.SupplierClass;
using IsTakip.Core.DTOs.SpecifiedDTOs;

namespace IsTakip.Core.Services
{
    public interface ISupplierService : IService<Supplier>
    {
        Task<List<SupplierWithBusinessDTO>> GetSupplierWithBusiness();
        Task<List<SupplierWithWareHouseInventoryDTO>> GetSupplierWithWareHouseInventory();
    }
}
