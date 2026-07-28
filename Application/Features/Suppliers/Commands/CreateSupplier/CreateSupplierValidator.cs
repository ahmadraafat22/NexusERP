using FluentValidation;

namespace NexusERP.Application.Features.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierValidator : AbstractValidator<CreateSupplierCommand>
    {
        public CreateSupplierValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name can't be empty")
                .MaximumLength(50).WithMessage("Name can't be more than 50 characters");

            RuleFor(c => c.PhoneNumber)
                .NotEmpty().WithMessage("Phone number can't be empty")
                .Matches(@"^01[0125][0-9]{8}$")
                .WithMessage("Phone number must be a valid Egyptian mobile number");

            RuleFor(c => c.Address)
                .MaximumLength(200)
                .WithMessage("Address can't be more than 200 characters");

            RuleFor(c => c.Email)
                .EmailAddress()
                .When(c => !string.IsNullOrWhiteSpace(c.Email))
                .WithMessage("Invalid email format");
        }
    }
}
