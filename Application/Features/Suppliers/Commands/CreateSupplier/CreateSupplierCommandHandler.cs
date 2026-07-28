using MediatR;
using NexusERP.Domain.Common.Enums;
using NexusERP.Domain.Entities;
using NexusERP.Domain.Interfaces;

namespace NexusERP.Application.Features.Suppliers.Commands.CreateSupplier
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, Guid>
    {
        private readonly IAppDbContext _context;
        private readonly ICodeGeneratorService _codeGenerator;
        public CreateSupplierCommandHandler(IAppDbContext context, ICodeGeneratorService codeGenerator)
        {
            _context = context;
            _codeGenerator = codeGenerator;
        }
        public async Task<Guid> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = new Supplier
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                Address = request.Address,
                Code = await _codeGenerator.GenerateCodeAsync(CodeType.Supplier)
            };
            await _context.Suppliers.AddAsync(supplier);
            await _context.SaveChangesAsync(cancellationToken);

            return supplier.Id;
        }
    }
}
