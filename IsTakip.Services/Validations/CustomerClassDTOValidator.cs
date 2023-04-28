using FluentValidation;
using IsTakip.Core.DTOs;

namespace IsTakip.Service.Validations
{
    public class CustomerClassDTOValidator : AbstractValidator<CustomerClassDTO>
    {
        public CustomerClassDTOValidator()
        {
            RuleFor(x => x.Description)
           .NotEmpty().WithMessage("Description is required.")
           .MaximumLength(150).WithMessage("Description must be maximum 150 characters.");

            RuleFor(x => x.Explanation)
                .MaximumLength(250).WithMessage("Explanation must be maximum 250 characters.");
        }
    }
}
