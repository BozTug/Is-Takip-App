using AutoMapper;
using IsTakip.Core.Classes.SupplierClass;
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
    public class SupplierServiceWithCaching : ISupplierService
    {
        private const string CacheSupplierKey = "suppliersCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memorycache;
        private readonly ISupplierRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public SupplierServiceWithCaching(IMapper mapper, IMemoryCache memorycache, ISupplierRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memorycache = memorycache;
            _repository = repository;
            _unitOfWork = unitOfWork;

            if (!_memorycache.TryGetValue(CacheSupplierKey, out _))
            {
                _memorycache.Set(CacheSupplierKey, _repository.GetAll().ToList());
            }

        }
        public async Task<Supplier> AddAsync(Supplier entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllSupplierAsync();
            return entity;
        }

        public async Task<IEnumerable<Supplier>> AddRangeAsync(IEnumerable<Supplier> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllSupplierAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Supplier, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Supplier entity)
        {
            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllSupplierAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<Supplier> entities)
        {
            _repository.DeleteRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllSupplierAsync();
        }

        public Task<IEnumerable<Supplier>> GetAllAsync()
        {
            return Task.FromResult(_memorycache.Get<IEnumerable<Supplier>>(CacheSupplierKey));
        }

        public Task<Supplier> GetByIdAsync(int id)
        {
            var supplier = _memorycache.Get<List<Supplier>>(CacheSupplierKey).FirstOrDefault(x => x.Id == id);
            if (supplier == null)
            {
                throw new NotFoundException($"{typeof(Supplier).Name}({id}) not found.");
            }
            return Task.FromResult(supplier);
        }

        public async Task<List<SupplierWithBusinessDTO>> GetSupplierWithBusiness()
        {
            var supplier = await _repository.GetSupplierWithBusiness();
            var supplierWithBusinessDto = _mapper.Map<List<SupplierWithBusinessDTO>>(supplier);
            return supplierWithBusinessDto;
        }

        public async Task<List<SupplierWithWareHouseInventoryDTO>> GetSupplierWithWareHouseInventory()
        {
            var supplier = await _repository.GetSupplierWithWareHouseInventory();
            var supplierWithWareHouseInventoryDto = _mapper.Map<List<SupplierWithWareHouseInventoryDTO>>(supplier);
            return supplierWithWareHouseInventoryDto;
        }

        public async Task UpdateAsync(Supplier entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllSupplierAsync();
        }

        public IQueryable<Supplier> Where(Expression<Func<Supplier, bool>> expression)
        {
            return _memorycache.Get<List<Supplier>>(CacheSupplierKey).Where(expression.Compile()).AsQueryable();
        }
        public async Task CacheAllSupplierAsync()
        {
            _memorycache.Set(CacheSupplierKey, await _repository.GetAll().ToListAsync());
        }

        public List<Supplier> GetAllList()
        {
            throw new NotImplementedException();
        }
    }
}
