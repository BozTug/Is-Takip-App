using AutoMapper;
using IsTakip.Core.Classes.CustomerClasses;
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
    public class CustomerClassServiceWithCaching : ICustomerClassService
    {
        private const string CacheCustomerClassKey = "customerClassesCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memorycache;
        private readonly ICustomerClassRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerClassServiceWithCaching(IMapper mapper, IMemoryCache memorycache, ICustomerClassRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memorycache = memorycache;
            _repository = repository;
            _unitOfWork = unitOfWork;

            if (!_memorycache.TryGetValue(CacheCustomerClassKey, out _))
            {
                _memorycache.Set(CacheCustomerClassKey, _repository.GetAll().ToList());
            }

        }

        public async Task<CustomerClass> AddAsync(CustomerClass entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCustomerClassesAsync();
            return entity;
        }

        public async Task<IEnumerable<CustomerClass>> AddRangeAsync(IEnumerable<CustomerClass> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllCustomerClassesAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<CustomerClass, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(CustomerClass entity)
        {
            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCustomerClassesAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<CustomerClass> entities)
        {
            _repository.DeleteRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllCustomerClassesAsync();
        }

        public Task<IEnumerable<CustomerClass>> GetAllAsync()
        {
            return Task.FromResult(_memorycache.Get<IEnumerable<CustomerClass>>(CacheCustomerClassKey));
        }

        public Task<CustomerClass> GetByIdAsync(int id)
        {
            var customerclass = _memorycache.Get<List<CustomerClass>>(CacheCustomerClassKey).FirstOrDefault(x => x.Id == id);
            if (customerclass == null)
            {
                throw new NotFoundException($"{typeof(CustomerClass).Name}({id}) not found.");
            }
            return Task.FromResult(customerclass);
        }

        public async Task<List<CustomerClassWithCustomerDTO>> GetCustomerClassWithCustomer(int id)
        {
            var customerClasses = await _repository.GetCustomerClassWithCustomer(id);
            var customerClassesWithCustomerDto = _mapper.Map<List<CustomerClassWithCustomerDTO>>(customerClasses);
            return customerClassesWithCustomerDto;

        }

        public async Task UpdateAsync(CustomerClass entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCustomerClassesAsync();
        }

        public IQueryable<CustomerClass> Where(Expression<Func<CustomerClass, bool>> expression)
        {
            return _memorycache.Get<List<CustomerClass>>(CacheCustomerClassKey).Where(expression.Compile()).AsQueryable();
        }
        public async Task CacheAllCustomerClassesAsync()
        {
            _memorycache.Set(CacheCustomerClassKey, await _repository.GetAll().ToListAsync());
        }

        public List<CustomerClass> GetAllList()
        {
            throw new NotImplementedException();
        }
    }
}
