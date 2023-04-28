using FluentValidation;
using IsTakip.Core.DTOs;

namespace IsTakip.Service.Validations
{
    public class JobfileDTOValidator : AbstractValidator<JobfileDTO>
    {
        public JobfileDTOValidator()
        {
            RuleFor(x => x.JobfileName)
            .NotEmpty().WithMessage("Job file name is required.")
            .MaximumLength(100).WithMessage("Job file name must not exceed 100 characters.");

            RuleFor(x => x.BusinessId)
                .NotEmpty().WithMessage("Business ID is required.");
        }
    }
}
