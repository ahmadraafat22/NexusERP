using FluentValidation;
namespace NexusERP.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(c => c.Id).NotEmpty()
                .WithMessage("Id cann't be empty ");

            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .Length(2, 50)
                .WithMessage("Name must be between 2 and 50 characters");

            RuleFor(c => c.Description)
                .MaximumLength(200)
                .WithMessage("description maximum length is 200 ");

        }
    }
}
