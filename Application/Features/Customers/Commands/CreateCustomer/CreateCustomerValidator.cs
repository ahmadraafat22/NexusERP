using FluentValidation;

namespace NexusERP.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name can't be empty ")
                .MaximumLength(50)
                .WithMessage("Name can't be more than 50 Charachter");
            RuleFor(c => c.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone number can't be empty ")
                .Matches(@"^01[0125][0-9]{8}$");
            RuleFor(c => c.Address)
                .MaximumLength(200)
                .WithMessage("address can't be more than 200 ");
            RuleFor(c => c.Email)
                .EmailAddress()
                .When(c => !string.IsNullOrEmpty(c.Email))
                .WithMessage("Invalid email format");

        }
    }
}
