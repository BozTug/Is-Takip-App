using FluentValidation;
using IsTakip.Core.DTOs;

namespace IsTakip.Service.Validations
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(25).WithMessage("Name must be maximum 25 characters.");
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname is required.")
                .MaximumLength(25).WithMessage("Surname must be maximum 25 characters.");
            RuleFor(x => x.UserPassword)
                .NotEmpty().WithMessage("Password is required.")
                .Matches("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,16}$")
                .WithMessage("Password must contain at least one letter and one number, and should be 8 to 16 characters long.");
            RuleFor(x => x.UserCode)
               .NotEmpty().WithMessage("Code is required.")
               .Matches("^(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,16}$")
               .WithMessage("User Code must contain at least one letter and one number, and should be 8 to 16 characters long.");
            RuleFor(x => x.CustomerId)
                .GreaterThan(0)
                .When(x => x.CustomerId != null)
                .WithMessage("CustomerId should be greater than 0.");
            RuleFor(x => x.RoleDescription)
                .NotEmpty().WithMessage("RoleDescription is required.");
            RuleFor(x => x.RoleDescription)
                .NotEmpty().MaximumLength(50);
            RuleFor(x => x.MailNotification)
                .IsInEnum().WithMessage("Invalid offer type.");
        }
    }
}
