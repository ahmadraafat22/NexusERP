using MediatR;
using NexusERP.Domain.Interfaces;

namespace NexusERP.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly IAppDbContext _context;
        private readonly ICodeGeneratorService _codeGenerator;
        public CreateCustomerCommandHandler(IAppDbContext context, ICodeGeneratorService codeGenerator)
        {
            _context = context;
            _codeGenerator = codeGenerator;
        }
        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new NexusERP.Domain.Entities.Customer
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Address = request.Address,
                Code = await _codeGenerator.GenerateCodeAsync(Domain.Common.Enums.CodeType.Customer)
            };
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync(cancellationToken);

            return customer.Id;
        }
    }
}
