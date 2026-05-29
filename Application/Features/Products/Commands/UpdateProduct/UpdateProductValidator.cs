using FluentValidation;

namespace NexusERP.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductValidator:AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Id is requird");

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("name is requird")
                .MaximumLength(100);

            RuleFor(p => p.SellingPrice)
                .GreaterThanOrEqualTo(0)
                .WithMessage("selling price cannot be less than 0");

            RuleFor(p => p.StockQuantity)
                .GreaterThanOrEqualTo(0)
                .WithMessage("stock quantity cannot be less than 0");

            RuleFor(p => p.CategoryId)
                .NotEmpty().WithMessage("category Id is required");
        }
    }
}
