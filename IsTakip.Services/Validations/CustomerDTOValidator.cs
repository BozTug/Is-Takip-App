using FluentValidation;
using IsTakip.Core.DTOs;

namespace IsTakip.Service.Validations
{
    public class CustomerDTOValidator : AbstractValidator<CustomerDTO>
    {
        public CustomerDTOValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email address is required.").EmailAddress().WithMessage("Please enter a valid email address.").When(x => !string.IsNullOrEmpty(x.Email));
            RuleFor(x => x.Address).NotNull().WithMessage("{PropertyName} is required.").NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(150).WithMessage("Address must not exceed 150 characters."); ;
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("{PropertyName} is required.").Matches(@"^\+?[0-9]*$").WithMessage("Phone number must consist of numbers only.").Length(6, 15).WithMessage("Phone number must be between 6 and 15 characters.");
            RuleFor(x => x.TaxAdministration).NotNull().WithMessage("{PropertyName} is required.").NotEmpty().WithMessage("{PropertyName} is required.").MaximumLength(50).WithMessage("Tax administration must not exceed 50 characters."); ;
            RuleFor(x => x.TaxNumber).Must(x => x.ToString().Length == 10).WithMessage("Tax number must be 10 digits long");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.").MaximumLength(150).WithMessage("Description must not exceed 150 characters.");
            RuleFor(x => x.Explanation).MaximumLength(250).WithMessage("Explanation must not exceed 250 characters.");
            RuleFor(x => x.CustomerClassId).GreaterThan(0).When(x => x.CustomerClassId.HasValue).WithMessage("Please select a valid customer class.");
            RuleFor(x => x.CustomerRestrictionId).GreaterThan(0).When(x => x.CustomerRestrictionId.HasValue).WithMessage("Please select a valid customer restriction.");
            RuleFor(x => x.CustomerRepresentativeId).GreaterThan(0).When(x => x.CustomerRepresentativeId.HasValue).WithMessage("Please select a valid customer representative.");
            RuleFor(x => x.UserId).GreaterThan(0).When(x => x.UserId.HasValue).WithMessage("Please select a valid user.");
        }
    }

}
