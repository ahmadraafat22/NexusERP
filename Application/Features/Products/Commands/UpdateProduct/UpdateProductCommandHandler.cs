using MediatR;
using Microsoft.EntityFrameworkCore;
using NexusERP.Application.Abstractions;

namespace NexusERP.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IAppDbContext _context;

        public UpdateProductCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p=> p.Id==request.Id,cancellationToken);

            if(product == null)
            {
                throw new Exception("Product not found ");
            }
            // mapping the new values (update values)
            product.Name = request.Name;
            product.SellingPrice = request.SellingPrice;
            product.StockQuantity = request.StockQuantity;
            product.CategoryId = request.CategoryId;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
