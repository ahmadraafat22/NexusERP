using MediatR;
using Microsoft.EntityFrameworkCore;
using NexusERP.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusERP.Application.Features.Products.Queries.GetProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
    {
        private readonly IAppDbContext _context;

        public GetAllProductsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products
                .Where(p => p.IsDeleted == false)
                .Select(p =>
                new ProductDto{
                    Id=p.Id,
                    Name=p.Name,
                    SellingPrice=p.SellingPrice,
                    StockQuantity=p.StockQuantity,
                    CategoryName=p.Category.Name
                }
                ).ToListAsync();

            return products;
            
        }
    }
}
