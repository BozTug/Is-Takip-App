using AutoMapper;
using IsTakip.Core.Classes.BuinessClasses;
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
    public class BusinessServiceWithCaching : IBusinessService
    {
        private const string CacheBusinessKey = "businessesCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memorycache;
        private readonly IBusinessRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BusinessServiceWithCaching(IUnitOfWork unitOfWork, IBusinessRepository repository, IMemoryCache memorycache, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _memorycache = memorycache;
            _mapper = mapper;

            if (!_memorycache.TryGetValue(CacheBusinessKey, out _))
            {
                _memorycache.Set(CacheBusinessKey, _repository.GetAll().ToList());
            }
        }

        public async Task<Business> AddAsync(Business entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllBusinessesAsync();
            return entity;
        }

        public async Task<IEnumerable<Business>> AddRangeAsync(IEnumerable<Business> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllBusinessesAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Business, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Business entity)
        {
            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllBusinessesAsync();

        }

        public async Task DeleteRangeAsync(IEnumerable<Business> entities)
        {
            _repository.DeleteRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllBusinessesAsync();
        }

        public Task<IEnumerable<Business>> GetAllAsync()
        {
            return Task.FromResult(_memorycache.Get<IEnumerable<Business>>(CacheBusinessKey));
        }

        public async Task<List<BusinessWithCustomerDTO>> GetBusinessWithCustomer(int id)
        {
            var businesses = await _repository.GetBusinessWithCustomer(id);
            var businesseswithcustomerDto = _mapper.Map<List<BusinessWithCustomerDTO>>(businesses);
            return businesseswithcustomerDto;
        }

        public async Task<List<BusinessWithJobfileDTO>> GetBusinessWithJobfile()
        {
            var businesses = await _repository.GetBusinessWithJobfile();
            var businesseswithjobfileDto = _mapper.Map<List<BusinessWithJobfileDTO>>(businesses);
            return businesseswithjobfileDto;
        }





        public async Task<List<BusinessWithSupplierDTO>> GetBusinessWithSupplier()
        {
            var businesses = await _repository.GetBusinessWithSupplier();
            var businesseswithsupplierDto = _mapper.Map<List<BusinessWithSupplierDTO>>(businesses);
            return businesseswithsupplierDto;
        }



        public Task<Business> GetByIdAsync(int id)
        {
            var business = _memorycache.Get<List<Business>>(CacheBusinessKey).FirstOrDefault(x => x.Id == id);
            if (business == null)
            {
                throw new NotFoundException($"{typeof(Business).Name}({id}) not found.");
            }
            return Task.FromResult(business);
        }

        public async Task UpdateAsync(Business entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllBusinessesAsync();
        }

        public IQueryable<Business> Where(Expression<Func<Business, bool>> expression)
        {
            return _memorycache.Get<List<Business>>(CacheBusinessKey).Where(expression.Compile()).AsQueryable();
        }

        public async Task CacheAllBusinessesAsync()
        {
            _memorycache.Set(CacheBusinessKey, await _repository.GetAll().ToListAsync());
        }

        public List<Business> GetAllList()
        {
            throw new NotImplementedException();
        }
    }
}
