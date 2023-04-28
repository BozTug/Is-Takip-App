using IsTakip.Core.Classes.SupplierClass;

namespace IsTakip.Core.Repositories
{
    public interface ISupplierRepository : IGenericRepository<Supplier>
    {

        Task<List<Supplier>> GetSupplierWithBusiness();
        Task<List<Supplier>> GetSupplierWithWareHouseInventory();
    }
}
