using MediatR;
using NexusERP.Application.Common.Exceptions;
using NexusERP.Domain.Interfaces;

namespace NexusERP.Application.Features.Customers.Commands.DeleteCustomer
{
    public class SoftDeleteCustomerCommandHandler : IRequestHandler<SoftDeleteCustomerCommand, bool>
    {
        private readonly IAppDbContext _context;
        public SoftDeleteCustomerCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(SoftDeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FindAsync(request.Id);

            if (customer == null)
                throw new NotFoundException(nameof(customer), request.Id);
            if (customer.IsDeleted)
                throw new Exception("Customer is already deleted before!");
            customer.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
