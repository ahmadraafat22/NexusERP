using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusERP.Application.Features.Categories.Commands.CreateCategoryCommand
{
    public class CreateCategoryValidator:AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100).WithMessage("Max length is 100")
                .Must(name => !string.IsNullOrWhiteSpace(name))
                .WithMessage("Name cannot be empty or spaces only");

            RuleFor(c => c.Description)
                .MaximumLength(200).WithMessage("description cannot be more than 200");
        }
    }
}
