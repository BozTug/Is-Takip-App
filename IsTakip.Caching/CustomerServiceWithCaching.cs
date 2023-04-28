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

    public class CustomerServiceWithCaching : ICustomerService
    {
        private const string CacheCustomerKey = "customersCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memorycache;
        private readonly ICustomerRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerServiceWithCaching(IMapper mapper, IMemoryCache memorycache, ICustomerRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memorycache = memorycache;
            _repository = repository;
            _unitOfWork = unitOfWork;

            if (!_memorycache.TryGetValue(CacheCustomerKey, out _))
            {
                _memorycache.Set(CacheCustomerKey, _repository.GetAll().ToList());
            }

        }

        public async Task<Customer> AddAsync(Customer entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCustomersAsync();
            return entity;

        }

        public async Task<IEnumerable<Customer>> AddRangeAsync(IEnumerable<Customer> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllCustomersAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Customer, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Customer entity)
        {
            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCustomersAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<Customer> entities)
        {
            _repository.DeleteRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllCustomersAsync();
        }

        public Task<IEnumerable<Customer>> GetAllAsync()
        {
            return Task.FromResult(_memorycache.Get<IEnumerable<Customer>>(CacheCustomerKey));
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            var customer = _memorycache.Get<List<Customer>>(CacheCustomerKey).FirstOrDefault(x => x.Id == id);
            if (customer == null)
            {
                throw new NotFoundException($"{typeof(Customer).Name}({id}) not found.");
            }
            return Task.FromResult(customer);
        }

        public async Task<List<CustomerWithAgendaDTO>> GetCustomerWithAgenda()
        {
            var customers = await _repository.GetCustomerWithAgenda();
            var customerWithAgendaDto = _mapper.Map<List<CustomerWithAgendaDTO>>(customers);
            return customerWithAgendaDto;
        }

        public async Task<List<CustomerWithBusinessDTO>> GetCustomerWithBusiness()
        {
            var customers = await _repository.GetCustomerWithBusiness();
            var customerWithBusinessDto = _mapper.Map<List<CustomerWithBusinessDTO>>(customers);
            return customerWithBusinessDto;
        }

        public async Task<List<CustomerWithCustomerClassDTO>> GetCustomerWithCustomerClass()
        {
            var customers = await _repository.GetCustomerWithCustomerClass();
            var customerWithCustomerClassDto = _mapper.Map<List<CustomerWithCustomerClassDTO>>(customers);
            return customerWithCustomerClassDto;
        }

        public async Task<List<CustomerWithCustomerRepresentativeDTO>> GetCustomerWithCustomerRepresentative()
        {
            var customers = await _repository.GetCustomerWithCustomerRepresentative();
            var customerWithCustomerRepresentativeDto = _mapper.Map<List<CustomerWithCustomerRepresentativeDTO>>(customers);
            return customerWithCustomerRepresentativeDto;
        }



        public async Task<List<CustomerWithWareHouseInventoryDTO>> GetCustomerWithWareHouseInventory()
        {
            var customers = await _repository.GetCustomerWithWareHouseInventory();
            var customerWithWareHouseInventoryDto = _mapper.Map<List<CustomerWithWareHouseInventoryDTO>>(customers);
            return customerWithWareHouseInventoryDto;
        }

        public async Task UpdateAsync(Customer entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllCustomersAsync();
        }

        public IQueryable<Customer> Where(Expression<Func<Customer, bool>> expression)
        {
            return _memorycache.Get<List<Customer>>(CacheCustomerKey).Where(expression.Compile()).AsQueryable();
        }
        public async Task CacheAllCustomersAsync()
        {
            _memorycache.Set(CacheCustomerKey, await _repository.GetAll().ToListAsync());
        }

        public List<Customer> GetAllList()
        {
            throw new NotImplementedException();
        }
    }
}
