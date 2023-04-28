using FluentValidation;
using IsTakip.Core.DTOs;

namespace IsTakip.Service.Validations
{
    public class ProductionLeadDTOValidator : AbstractValidator<ProductionLeadDTO>
    {
        public ProductionLeadDTOValidator()
        {
            RuleFor(x => x.ProductionOrderId)
          .NotEmpty().WithMessage("Production order ID is required.");

            RuleFor(x => x.LeadTime)
          .GreaterThan(0).WithMessage("Lead time must be greater than 0.");

            RuleFor(x => x.ProductionLeadTypeId)
                .NotEmpty().WithMessage("Production lead type ID is required.");
        }
    }
}
