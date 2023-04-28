using FluentValidation;
using IsTakip.Core.DTOs;

namespace IsTakip.Service.Validations
{
    public class SupplierDTOValidator : AbstractValidator<SupplierDTO>
    {
        public SupplierDTOValidator()
        {
            RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(50).WithMessage("Description can be at most 50 characters long.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^[0-9]{10}$").WithMessage("Please enter a valid phone number.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Please enter a valid email address.");

            RuleFor(x => x.Explanation)
                .NotEmpty().WithMessage("Explanation is required.")
                .MaximumLength(150).WithMessage("Explanation can be at most 150 characters long.");
        }
    }
}
