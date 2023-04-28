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
    public class WareHouseShelfServiceWithCaching : IWareHouseShelfService
    {
        private const string CacheWareHouseShelfKey = "warehouseShelvesCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memorycache;
        private readonly IWareHouseShelfRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public WareHouseShelfServiceWithCaching(IMapper mapper, IMemoryCache memorycache, IWareHouseShelfRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memorycache = memorycache;
            _repository = repository;
            _unitOfWork = unitOfWork;

            if (!_memorycache.TryGetValue(CacheWareHouseShelfKey, out _))
            {
                _memorycache.Set(CacheWareHouseShelfKey, _repository.GetAll().ToList());
            }

        }
        public async Task<WareHouseShelf> AddAsync(WareHouseShelf entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllWareHouseShelfAsync();
            return entity;
        }

        public async Task<IEnumerable<WareHouseShelf>> AddRangeAsync(IEnumerable<WareHouseShelf> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllWareHouseShelfAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<WareHouseShelf, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(WareHouseShelf entity)
        {
            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllWareHouseShelfAsync();

        }

        public async Task DeleteRangeAsync(IEnumerable<WareHouseShelf> entities)
        {
            _repository.DeleteRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllWareHouseShelfAsync();
        }

        public Task<IEnumerable<WareHouseShelf>> GetAllAsync()
        {
            return Task.FromResult(_memorycache.Get<IEnumerable<WareHouseShelf>>(CacheWareHouseShelfKey));
        }

        public Task<WareHouseShelf> GetByIdAsync(int id)
        {
            var warehouseShelf = _memorycache.Get<List<WareHouseShelf>>(CacheWareHouseShelfKey).FirstOrDefault(x => x.Id == id);
            if (warehouseShelf == null)
            {
                throw new NotFoundException($"{typeof(WareHouseShelf).Name}({id}) not found.");
            }
            return Task.FromResult(warehouseShelf);
        }

        public async Task<List<WareHouseShelfWithWarehouseDTO>> GetWareHouseShelfWithWarehouse()
        {
            var warehouseShelf = await _repository.GetWareHouseShelfWithWarehouse();
            var warehouseShelfWithWarehouseDto = _mapper.Map<List<WareHouseShelfWithWarehouseDTO>>(warehouseShelf);
            return warehouseShelfWithWarehouseDto;
        }

        public async Task<List<WareHouseShelfWithWareHouseInventoryDTO>> GetWareHouseShelfWithWarehouseInventory()
        {
            var warehouseShelf = await _repository.GetWareHouseShelfWithWareHouseInventory();
            var warehouseShelfWithWarehouseInventoryDto = _mapper.Map<List<WareHouseShelfWithWareHouseInventoryDTO>>(warehouseShelf);
            return warehouseShelfWithWarehouseInventoryDto;
        }

        public async Task UpdateAsync(WareHouseShelf entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllWareHouseShelfAsync();
        }

        public IQueryable<WareHouseShelf> Where(Expression<Func<WareHouseShelf, bool>> expression)
        {
            return _memorycache.Get<List<WareHouseShelf>>(CacheWareHouseShelfKey).Where(expression.Compile()).AsQueryable();
        }
        public async Task CacheAllWareHouseShelfAsync()
        {
            _memorycache.Set(CacheWareHouseShelfKey, await _repository.GetAll().ToListAsync());
        }

        public List<WareHouseShelf> GetAllList()
        {
            throw new NotImplementedException();
        }
    }
}
