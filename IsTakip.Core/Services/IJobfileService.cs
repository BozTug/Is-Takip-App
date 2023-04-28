using IsTakip.Core.Classes.BuinessClasses;
using IsTakip.Core.DTOs.SpecifiedDTOs;

namespace IsTakip.Core.Services
{
    public interface IJobfileService : IService<Jobfile>
    {
        Task<List<JobfileWithBusinessDTO>> GetJobfileWithBusiness();

    }
}
