using FluentValidation;
using IsTakip.Core.DTOs;

namespace IsTakip.Service.Validations
{
    public class BusinessDTOValidator : AbstractValidator<BusinessDTO>
    {
        public BusinessDTOValidator()
        {
            RuleFor(x => x.CustomerId)
            .GreaterThan(0).WithMessage("Customer ID must be greater than zero.");

            RuleFor(x => x.OfferType)
                .IsInEnum().WithMessage("Invalid offer type.");

            RuleFor(x => x.OfferNo)
                .GreaterThan(0).WithMessage("Offer number must be greater than zero.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(x => x.EndNoticeSituation)
                .IsInEnum().WithMessage("Invalid end notice situation.");



            RuleFor(x => x.BusinessPriority)
                .IsInEnum().WithMessage("Invalid business priority.");

            RuleFor(x => x.CustomerOrderNo)
                .GreaterThan(0).WithMessage("Customer order number must be greater than zero.");

            RuleFor(x => x.BusinessNote)
                .NotEmpty().WithMessage("Business note is required.")
                .MaximumLength(250).WithMessage("Business note can't be longer than 250 characters.");

           

            RuleFor(x => x.Workmanship)
                .NotNull().WithMessage("Workmanship is required.");

            RuleFor(x => x.SupplierId)
                .GreaterThan(0).WithMessage("Supplier ID must be greater than zero.");

            RuleFor(x => x.MaterialNote)
                .NotEmpty().WithMessage("Material note is required.")
                .MaximumLength(100).WithMessage("Material note can't be longer than 100 characters.");
        }
    }
}
