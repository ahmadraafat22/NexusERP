using MediatR;
using Microsoft.EntityFrameworkCore;
using NexusERP.Application.Abstractions;
using NexusERP.Application.Features.Products.commands.createProduct;
using NexusERP.Domain.Entities;

namespace NexusERP.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IAppDbContext _context;

        public CreateProductHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var CategoryExists = await _context.Categories
                .AnyAsync(c => c.Id == request.CategoryId);
            if (!CategoryExists)
            {
                throw new Exception("Category not found");
            }
            // manual mapping 
            var product = new Product()
            {
                Name = request.Name,
                Description = request.Description,
                SKU = request.SKU,
                Barcode = request.Barcode,
                CostPrice = request.CostPrice,
                SellingPrice = request.SellingPrice,
                StockQuantity = request.StockQuantity,
                CategoryId = request.CategoryId,
                CreatedAt = DateTime.UtcNow
            };
            // adding 
            await _context.Products.AddAsync(product);
            // save 
            await _context.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
