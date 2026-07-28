using MediatR;
using NexusERP.Application.Common.Exceptions;
using NexusERP.Domain.Interfaces;

namespace NexusERP.Application.Features.Suppliers.Queries.GetSupplierById
{
    public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, GetSupplierByIdDto>
    {
        private readonly IAppDbContext _context;
        public GetSupplierByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<GetSupplierByIdDto> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            var supplier = await _context.Suppliers.FindAsync(request.Id);
            if (supplier == null)
            {
                throw new NotFoundException(nameof(supplier), request.Id);
            }
            if (supplier.IsDeleted)
            {
                throw new Exception("Supplier is already deleted!");
            }
            var SupplierDto = new GetSupplierByIdDto
            {
                Name = supplier.Name,
                PhoneNumber = supplier.PhoneNumber,
                Email = supplier.Email,
                Address = supplier.Address
            };
            return SupplierDto;
        }
    }
}
