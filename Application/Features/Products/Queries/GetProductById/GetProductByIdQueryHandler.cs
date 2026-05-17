using MediatR;
using Microsoft.EntityFrameworkCore;
using NexusERP.Application.Abstractions;
using NexusERP.Application.Features.Products.Queries.GetProducts;
namespace NexusERP.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryHandler:IRequestHandler<GetProductByIdQuery,ProductDto>
    {
        private readonly IAppDbContext _context;

        public GetProductByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .Where(p=>p.IsDeleted==false)
                .Where(p => p.Id == request.Id)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    SellingPrice = p.SellingPrice,
                    Description = p.Description,
                    CategoryName = p.Category.Name
                })
                .FirstOrDefaultAsync();
            if (product == null)
            {
                 throw new Exception("product not found ");
            }
            return product;
        }
    }
}
