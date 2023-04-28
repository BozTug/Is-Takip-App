using AutoMapper;
using IsTakip.Core.Classes.WareHouseClasses;
using IsTakip.Core.DTOs.SpecifiedDTOs;
using IsTakip.Core.Repositories;
using IsTakip.Core.Services;
using IsTakip.Core.UnitOfWorks;
using IsTakip.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Linq.Expressions;

namespace IsTakip.Caching
{
    public class WareHouseInventoryServiceWithCaching : IWareHouseInventoryService
    {
        private const string CacheWareHouseInventoryKey = "warehouseInventoriesCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memorycache;
        private readonly IWareHouseInventoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public WareHouseInventoryServiceWithCaching(IMapper mapper, IMemoryCache memorycache, IWareHouseInventoryRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memorycache = memorycache;
            _repository = repository;
            _unitOfWork = unitOfWork;

            if (!_memorycache.TryGetValue(CacheWareHouseInventoryKey, out _))
            {
                _memorycache.Set(CacheWareHouseInventoryKey, _repository.GetAll().ToList());
            }

        }
        public async Task<WareHouseInventory> AddAsync(WareHouseInventory entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllWareHouseInventoryAsync();
            return entity;
        }

        public async Task<IEnumerable<WareHouseInventory>> AddRangeAsync(IEnumerable<WareHouseInventory> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllWareHouseInventoryAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<WareHouseInventory, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(WareHouseInventory entity)
        {
            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllWareHouseInventoryAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<WareHouseInventory> entities)
        {
            _repository.DeleteRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllWareHouseInventoryAsync();
        }

        public Task<IEnumerable<WareHouseInventory>> GetAllAsync()
        {
            return Task.FromResult(_memorycache.Get<IEnumerable<WareHouseInventory>>(CacheWareHouseInventoryKey));
        }

        public Task<WareHouseInventory> GetByIdAsync(int id)
        {
            var warehouseinventory = _memorycache.Get<List<WareHouseInventory>>(CacheWareHouseInventoryKey).FirstOrDefault(x => x.Id == id);
            if (warehouseinventory == null)
            {
                throw new NotFoundException($"{typeof(WareHouseInventory).Name}({id}) not found.");
            }
            return Task.FromResult(warehouseinventory);
        }

        public async Task<List<WareHouseInventoryWithCustomerDTO>> GetWareHouseInventoryWithCustomer()
        {
            var warehouseinventory = await _repository.GetWareHouseInventoryWithCustomer();
            var warehouseinventoryWithCustomerDto = _mapper.Map<List<WareHouseInventoryWithCustomerDTO>>(warehouseinventory);
            return warehouseinventoryWithCustomerDto;
        }



        public async Task<List<WareHouseInventoryWithSupplierDTO>> GetWareHouseInventoryWithSupplier()
        {
            var warehouseinventory = await _repository.GetWareHouseInventoryWithSupplier();
            var warehouseinventoryWithSupplierDto = _mapper.Map<List<WareHouseInventoryWithSupplierDTO>>(warehouseinventory);
            return warehouseinventoryWithSupplierDto;
        }



        public async Task<List<WareHouseInventoryWithWarehouseDTO>> GetWareHouseInventoryWithWarehouse()
        {
            var warehouseinventory = await _repository.GetWareHouseInventoryWithWarehouse();
            var warehouseinventoryWithWarehouseDto = _mapper.Map<List<WareHouseInventoryWithWarehouseDTO>>(warehouseinventory);
            return warehouseinventoryWithWarehouseDto;
        }

        public async Task<List<WareHouseInventoryWithWareHouseShelfDTO>> GetWareHouseInventoryWithWareHouseShelf()
        {
            var warehouseinventory = await _repository.GetWareHouseInventoryWithWareHouseShelf();
            var warehouseinventoryWithWarehouseShelfDto = _mapper.Map<List<WareHouseInventoryWithWareHouseShelfDTO>>(warehouseinventory);
            return warehouseinventoryWithWarehouseShelfDto;
        }

        public async Task UpdateAsync(WareHouseInventory entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllWareHouseInventoryAsync();
        }

        public IQueryable<WareHouseInventory> Where(Expression<Func<WareHouseInventory, bool>> expression)
        {
            return _memorycache.Get<List<WareHouseInventory>>(CacheWareHouseInventoryKey).Where(expression.Compile()).AsQueryable();
        }
        public async Task CacheAllWareHouseInventoryAsync()
        {
            _memorycache.Set(CacheWareHouseInventoryKey, await _repository.GetAll().ToListAsync());
        }

        public List<WareHouseInventory> GetAllList()
        {
            throw new NotImplementedException();
        }
    }
}
