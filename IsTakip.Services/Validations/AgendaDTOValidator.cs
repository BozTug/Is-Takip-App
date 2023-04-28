using FluentValidation;
using IsTakip.Core.DTOs;

namespace IsTakip.Service.Validations
{
    public class AgendaDTOValidator : AbstractValidator<AgendaDTO>
    {
        public AgendaDTOValidator()
        {
            RuleFor(x => x.CustomerId).GreaterThan(0).WithMessage("Customer ID must be greater than zero.");
            RuleFor(x => x.Explanation).NotEmpty().WithMessage("Explanation is required.").MaximumLength(250).WithMessage("Explanation can't be longer than 250 characters.");
            
        }
    }
}
