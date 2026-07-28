using MediatR;
using NexusERP.Application.Common.Exceptions;
using NexusERP.Domain.Interfaces;

namespace NexusERP.Application.Features.Suppliers.Commands.SoftDeleteSupplier
{
    public class SoftDeleteSupplierCommadHandler : IRequestHandler<SoftDeleteSupplierCommand, bool>
    {
        private readonly IAppDbContext _context;
        public SoftDeleteSupplierCommadHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(SoftDeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _context.Suppliers.FindAsync(request.Id);

            if (supplier == null)
            {
                throw new NotFoundException(nameof(supplier), request.Id);
            }
            if (supplier.IsDeleted)
            {
                throw new Exception("this supplier is already deleted!");
            }

            supplier.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
