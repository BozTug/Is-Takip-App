using FluentValidation;
using IsTakip.Core.DTOs;

namespace IsTakip.Service.Validations
{
    public class WarehouseDTOValidator : AbstractValidator<WarehouseDTO>
    {
        public WarehouseDTOValidator()
        {
            RuleFor(x => x.Description)
           .NotEmpty().WithMessage("Description is required.")
           .MaximumLength(50).WithMessage("Description can be at most 50 characters long.");

            RuleFor(x => x.Explanation)
                .MaximumLength(100).WithMessage("Explanation can be at most 100 characters long.");

            RuleFor(x => x.Officer)
               .NotEmpty().WithMessage("Name is required.")
               .MaximumLength(25).WithMessage("Name must be maximum 25 characters.");
            RuleFor(x => x.OfficerPhone)
               .NotEmpty().WithMessage("Phone number is required.")
               .Matches(@"^[0-9]+$").WithMessage("Please enter a valid phone number.")
               .MaximumLength(15).WithMessage("Phone number must be maximum 15 digits.");
        }
    }
}
