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
    public class WarehouseServiceWithCaching : IWarehouseService
    {
        private const string CacheWarehouseKey = "warehousesCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memorycache;
        private readonly IWarehouseRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public WarehouseServiceWithCaching(IMapper mapper, IMemoryCache memorycache, IWarehouseRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memorycache = memorycache;
            _repository = repository;
            _unitOfWork = unitOfWork;

            if (!_memorycache.TryGetValue(CacheWarehouseKey, out _))
            {
                _memorycache.Set(CacheWarehouseKey, _repository.GetAll().ToList());
            }

        }
        public async Task<Warehouse> AddAsync(Warehouse entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllWarehouseAsync();
            return entity;
        }

        public async Task<IEnumerable<Warehouse>> AddRangeAsync(IEnumerable<Warehouse> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllWarehouseAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Warehouse, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Warehouse entity)
        {
            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllWarehouseAsync();

        }

        public async Task DeleteRangeAsync(IEnumerable<Warehouse> entities)
        {
            _repository.DeleteRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllWarehouseAsync();

        }

        public Task<IEnumerable<Warehouse>> GetAllAsync()
        {
            return Task.FromResult(_memorycache.Get<IEnumerable<Warehouse>>(CacheWarehouseKey));
        }

        public Task<Warehouse> GetByIdAsync(int id)
        {
            var warehouse = _memorycache.Get<List<Warehouse>>(CacheWarehouseKey).FirstOrDefault(x => x.Id == id);
            if (warehouse == null)
            {
                throw new NotFoundException($"{typeof(Warehouse).Name}({id}) not found.");
            }
            return Task.FromResult(warehouse);
        }

        public async Task<List<WarehouseWithWareHouseInventoryDTO>> GetWarehouseWithWareHouseInventory()
        {
            var warehouse = await _repository.GetWarehouseWithWareHouseInventory();
            var warehouseWithWarehouseInventoryDto = _mapper.Map<List<WarehouseWithWareHouseInventoryDTO>>(warehouse);
            return warehouseWithWarehouseInventoryDto;
        }

        public async Task<List<WarehouseWithWareHouseShelfDTO>> GetWarehouseWithWareHouseShelf()
        {
            var warehouse = await _repository.GetWarehouseWithWareHouseShelf();
            var warehouseWithWarehouseShelfDto = _mapper.Map<List<WarehouseWithWareHouseShelfDTO>>(warehouse);
            return warehouseWithWarehouseShelfDto;
        }

        public async Task UpdateAsync(Warehouse entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllWarehouseAsync();
        }

        public IQueryable<Warehouse> Where(Expression<Func<Warehouse, bool>> expression)
        {
            return _memorycache.Get<List<Warehouse>>(CacheWarehouseKey).Where(expression.Compile()).AsQueryable();
        }
        public async Task CacheAllWarehouseAsync()
        {
            _memorycache.Set(CacheWarehouseKey, await _repository.GetAll().ToListAsync());
        }

        public List<Warehouse> GetAllList()
        {
            throw new NotImplementedException();
        }
    }
}
