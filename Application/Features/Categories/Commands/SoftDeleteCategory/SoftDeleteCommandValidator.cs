using FluentValidation;

namespace NexusERP.Application.Features.Categories.Commands.SoftDeleteCategory
{
    public class SoftDeleteCommandValidator : AbstractValidator<SoftDeleteCategoryCommand>
    {
        public SoftDeleteCommandValidator()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("Id is required");
        }
    }
}
