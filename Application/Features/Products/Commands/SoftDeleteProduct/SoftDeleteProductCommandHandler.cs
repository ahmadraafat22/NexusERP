using MediatR;
using Microsoft.EntityFrameworkCore;
using NexusERP.Application.Common.Exceptions;
using NexusERP.Domain.Interfaces;

namespace NexusERP.Application.Features.Products.Commands.SoftDeleteProduct
{
    public class SoftDeleteProductCommandHandler : IRequestHandler<SoftDeleteProductCommand, bool>
    {
        private readonly IAppDbContext _context;
        public SoftDeleteProductCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(SoftDeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .Where(p => p.Id == request.Id)
                .FirstOrDefaultAsync(cancellationToken);
            if (product == null)
            {
                throw new NotFoundException(nameof(request), request.Id);
            }
            product.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
