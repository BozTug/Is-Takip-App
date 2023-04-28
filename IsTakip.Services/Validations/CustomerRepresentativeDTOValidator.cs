using FluentValidation;
using IsTakip.Core.DTOs;

namespace IsTakip.Service.Validations
{
    public class CustomerRepresentativeDTOValidator : AbstractValidator<CustomerRepresentativeDTO>
    {
        public CustomerRepresentativeDTOValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(25).WithMessage("Name must be maximum 25 characters.");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname is required.")
                .MaximumLength(25).WithMessage("Surname must be maximum 25 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Please enter a valid email address.")
                .MaximumLength(100).WithMessage("Email must be maximum 100 characters.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^[0-9]+$").WithMessage("Please enter a valid phone number.")
                .MaximumLength(15).WithMessage("Phone number must be maximum 15 digits.");

            RuleFor(x => x.CustomerId)
                .GreaterThan(0).WithMessage("Customer ID must be greater than 0.");
        }
    }
}
