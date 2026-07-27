using MediatR;
using Microsoft.EntityFrameworkCore;
using NexusERP.Application.Common.CustomResponse;
using NexusERP.Application.Common.Extensions;
using NexusERP.Domain.Interfaces;

namespace NexusERP.Application.Features.Products.Queries.GetProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PaginatedResponse<ProductDto>>
    {
        private readonly IAppDbContext _context;

        public GetAllProductsQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<PaginatedResponse<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {

            var query = _context.Products.AsNoTracking()
                .AsQueryable();
            if (!string.IsNullOrEmpty(request.Search))
            {
                var search = request.Search.Trim();
                query = query.Where(p => EF.Functions.Like(p.Name, $"%{search}%"));
            }
            if (request.MaxPrice != null)
            {
                query = query.Where(p => p.SellingPrice <= request.MaxPrice);
            }
            if (request.MinPrice != null)
            {
                query = query.Where(p => p.SellingPrice >= request.MinPrice);
            }
            return await query
                .OrderBy(p => p.Id)
                .Select(p =>
                new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    SellingPrice = p.SellingPrice,
                    StockQuantity = p.StockQuantity,
                    CategoryName = p.Category.Name
                })
                .ToPaginatedResponseAsync(request.PageNumber, request.PageSize, cancellationToken);


        }
    }
}
