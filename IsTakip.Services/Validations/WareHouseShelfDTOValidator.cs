using FluentValidation;
using IsTakip.Core.DTOs;

namespace IsTakip.Service.Validations
{
    public class WareHouseShelfDTOValidator : AbstractValidator<WareHouseShelfDTO>
    {
        public WareHouseShelfDTOValidator()
        {
            RuleFor(x => x.Description)
           .NotEmpty().WithMessage("Description is required.")
           .MaximumLength(100).WithMessage("Description cannot be longer than 100 characters.");

            RuleFor(x => x.Explanation)
                .NotEmpty().WithMessage("Explanation is required.")
                .MaximumLength(250).WithMessage("Explanation cannot be longer than 250 characters.");

            RuleFor(x => x.WareHouseId)
                .NotEmpty().WithMessage("Warehouse ID is required.")
                .GreaterThan(0).WithMessage("Warehouse ID must be greater than 0.");
        }
    }
}
