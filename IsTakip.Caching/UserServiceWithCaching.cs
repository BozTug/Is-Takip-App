using AutoMapper;
using IsTakip.Core.Classes.UserClasses;
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
    public class UserServiceWithCaching : IUserService
    {
        private const string CacheUserKey = "usersCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memorycache;
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserServiceWithCaching(IMapper mapper, IMemoryCache memorycache, IUserRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memorycache = memorycache;
            _repository = repository;
            _unitOfWork = unitOfWork;

            if (!_memorycache.TryGetValue(CacheUserKey, out _))
            {
                _memorycache.Set(CacheUserKey, _repository.GetAll().ToList());
            }

        }
        public async Task<User> AddAsync(User entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllUserAsync();
            return entity;
        }

        public async Task<IEnumerable<User>> AddRangeAsync(IEnumerable<User> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllUserAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(User entity)
        {
            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllUserAsync();

        }

        public async Task DeleteRangeAsync(IEnumerable<User> entities)
        {
            _repository.DeleteRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllUserAsync();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            return Task.FromResult(_memorycache.Get<IEnumerable<User>>(CacheUserKey));
        }

        public Task<User> GetByIdAsync(int id)
        {
            var user = _memorycache.Get<List<User>>(CacheUserKey).FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                throw new NotFoundException($"{typeof(User).Name}({id}) not found.");
            }
            return Task.FromResult(user);
        }

        public async Task<List<UserWithCustomerDTO>> GetUserWithCustomer()
        {
            var user = await _repository.GetUserWithCustomer();
            var userWithCustomerDto = _mapper.Map<List<UserWithCustomerDTO>>(user);
            return userWithCustomerDto;
        }

        public async Task UpdateAsync(User entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllUserAsync();
        }

        public IQueryable<User> Where(Expression<Func<User, bool>> expression)
        {
            return _memorycache.Get<List<User>>(CacheUserKey).Where(expression.Compile()).AsQueryable();
        }
        public async Task CacheAllUserAsync()
        {
            _memorycache.Set(CacheUserKey, await _repository.GetAll().ToListAsync());
        }

        public List<User> GetAllList()
        {
            throw new NotImplementedException();
        }
    }
}
