using FluentValidation;

namespace NexusERP.Application.Features.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierValidator : AbstractValidator<UpdateSupplierCommand>
    {
        public UpdateSupplierValidator()
        {
            RuleFor(s => s.Id)
           .NotEqual(Guid.Empty)
           .WithMessage("Invalid Supplier id");

            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("Name can't be empty")
                .MaximumLength(50).WithMessage("Name can't be more than 50 charasters");

            RuleFor(s => s.PhoneNumber)
                .NotEmpty().WithMessage("Phone number can't be empty")
                .Matches(@"^01[0125][0-9]{8}$")
                .WithMessage("Phone number must be a valid Egyptian mobile number");

            RuleFor(s => s.Address)
                .MaximumLength(200)
                .WithMessage("Address can't be more than 200 characters");

            RuleFor(s => s.Email)
                .EmailAddress()
                .When(s => !string.IsNullOrWhiteSpace(s.Email))
                .WithMessage("Invalid email format");
        }
    }
}
