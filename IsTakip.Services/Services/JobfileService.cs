using AutoMapper;
using IsTakip.Core.Classes.BuinessClasses;
using IsTakip.Core.DTOs.SpecifiedDTOs;
using IsTakip.Core.Repositories;
using IsTakip.Core.Services;
using IsTakip.Core.UnitOfWorks;

namespace IsTakip.Service.Services
{
    public class JobfileService : Service<Jobfile>, IJobfileService
    {
        private readonly IJobfileRepository _jobfilerepository;
        private readonly IMapper _mapper;
        public JobfileService(IGenericRepository<Jobfile> repository, IUnitOfWork unitOfWork, IMapper mapper, IJobfileRepository jobfilerepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _jobfilerepository = jobfilerepository;
        }

        public async Task<List<JobfileWithBusinessDTO>> GetJobfileWithBusiness()
        {
            var jobfiles = await _jobfilerepository.GetJobfileWithBusiness();
            var jobfilesDto = _mapper.Map<List<JobfileWithBusinessDTO>>(jobfiles);
            return jobfilesDto;
        }
    }
}
