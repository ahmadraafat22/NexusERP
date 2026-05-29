using FluentValidation;

namespace NexusERP.Application.Features.Products.Commands.SoftDeleteProduct
{
    public class SoftDeleteProductValidator:AbstractValidator<SoftDeleteProductCommand>
    {
        public SoftDeleteProductValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Id is required");
        }
    }
}
