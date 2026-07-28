using MediatR;
using NexusERP.Application.Common.Exceptions;
using NexusERP.Domain.Interfaces;

namespace NexusERP.Application.Features.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, bool>
    {
        private readonly IAppDbContext _context;
        public UpdateSupplierCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _context.Suppliers.FindAsync(request.Id);
            if (supplier == null)
            {
                throw new NotFoundException(nameof(supplier), request.Id);
            }
            if (supplier.IsDeleted)
            {
                throw new Exception("Supplier is already Deleted!");
            }
            supplier.Name = request.Name;
            supplier.PhoneNumber = request.PhoneNumber;
            supplier.Email = request.Email;
            supplier.Address = request.Address;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
