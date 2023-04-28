using FluentValidation;
using IsTakip.Core.DTOs;

namespace IsTakip.Service.Validations
{
    public class WareHouseInventoryDTOValidator : AbstractValidator<WareHouseInventoryDTO>
    {
        public WareHouseInventoryDTOValidator()
        {
            RuleFor(x => x.WareHouseId)
               .GreaterThan(0)
               .When(x => x.WareHouseId != null)
               .WithMessage("WareHouse ID should be greater than 0.");
            RuleFor(x => x.WareHouseShelfId)
               .GreaterThan(0)
               .When(x => x.WareHouseShelfId != null)
               .WithMessage("Warehouse Shelf Id should be greater than 0.");
            RuleFor(x => x.CustomerId)
              .GreaterThan(0)
              .When(x => x.CustomerId != null)
              .WithMessage("Customer ID should be greater than 0.");

            RuleFor(x => x.SupplierId)
             .GreaterThan(0)
             .When(x => x.SupplierId != null)
             .WithMessage("Supplier ID should be greater than 0.");
            RuleFor(x => x.Width)
            .NotEmpty().WithMessage("Width is required.").GreaterThan(0).WithMessage("Width should be greater than 0.");

            RuleFor(x => x.Length)
                .NotEmpty().WithMessage("Length is required.").GreaterThan(0).WithMessage("Length should be greater than 0.");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Amount is required.").GreaterThan(0).WithMessage("Amount should be greater than 0.");

            RuleFor(x => x.Weight)
                .NotEmpty().WithMessage("Weight is required.").GreaterThan(0).WithMessage("Weight should be greater than 0.");

            RuleFor(x => x.Explanation)
                .NotEmpty().WithMessage("Explanation is required.").MaximumLength(500).WithMessage("Explanation should be at most 500 characters.");


        }
    }
}
