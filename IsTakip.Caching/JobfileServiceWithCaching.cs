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
    public class JobfileServiceWithCaching : IJobfileService
    {
        private const string CacheJobfileKey = "jobfilesCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memorycache;
        private readonly IJobfileRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public JobfileServiceWithCaching(IMapper mapper, IMemoryCache memorycache, IJobfileRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memorycache = memorycache;
            _repository = repository;
            _unitOfWork = unitOfWork;

            if (!_memorycache.TryGetValue(CacheJobfileKey, out _))
            {
                _memorycache.Set(CacheJobfileKey, _repository.GetAll().ToList());
            }

        }

        public async Task<Jobfile> AddAsync(Jobfile entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllJobfilesAsync();
            return entity;
        }

        public async Task<IEnumerable<Jobfile>> AddRangeAsync(IEnumerable<Jobfile> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllJobfilesAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Jobfile, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Jobfile entity)
        {
            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllJobfilesAsync();
        }

        public async Task DeleteRangeAsync(IEnumerable<Jobfile> entities)
        {
            _repository.DeleteRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllJobfilesAsync();
        }

        public Task<IEnumerable<Jobfile>> GetAllAsync()
        {
            return Task.FromResult(_memorycache.Get<IEnumerable<Jobfile>>(CacheJobfileKey));
        }

        public Task<Jobfile> GetByIdAsync(int id)
        {
            var jobfile = _memorycache.Get<List<Jobfile>>(CacheJobfileKey).FirstOrDefault(x => x.Id == id);
            if (jobfile == null)
            {
                throw new NotFoundException($"{typeof(Jobfile).Name}({id}) not found.");
            }
            return Task.FromResult(jobfile);
        }

        public async Task<List<JobfileWithBusinessDTO>> GetJobfileWithBusiness()
        {
            var jobfiles = await _repository.GetJobfileWithBusiness();
            var jobfileWithBusinessDto = _mapper.Map<List<JobfileWithBusinessDTO>>(jobfiles);
            return jobfileWithBusinessDto;
        }

        public async Task UpdateAsync(Jobfile entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllJobfilesAsync();
        }

        public IQueryable<Jobfile> Where(Expression<Func<Jobfile, bool>> expression)
        {
            return _memorycache.Get<List<Jobfile>>(CacheJobfileKey).Where(expression.Compile()).AsQueryable();
        }
        public async Task CacheAllJobfilesAsync()
        {
            _memorycache.Set(CacheJobfileKey, await _repository.GetAll().ToListAsync());
        }

        public List<Jobfile> GetAllList()
        {
            throw new NotImplementedException();
        }
    }
}
