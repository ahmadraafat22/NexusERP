using MediatR;
using Microsoft.EntityFrameworkCore;
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
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
            if (product == null)
            {
                throw new Exception("not found Product");
            }
            if (product.IsDeleted)
            {
                throw new Exception("This product already Deleted"!);
            }
            product.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
