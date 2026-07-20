using FluentValidation;

namespace NexusERP.Application.Features.Categories.Commands.CreateCategoryCommand
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name cannot be empty or spaces only")
                .MaximumLength(100).WithMessage("Max length is 100");

            RuleFor(c => c.Description)
                .MaximumLength(200).WithMessage("description cannot be more than 200");
        }
    }
}
