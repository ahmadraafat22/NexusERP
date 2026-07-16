using MediatR;
using Microsoft.EntityFrameworkCore;
using NexusERP.Domain.Interfaces;
using NexusERP.Application.Common.CustomResponse;

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
            if (request.PageNumber < 1)
                request.PageNumber = 1;
            if (request.PageSize > 50)
                request.PageSize = 50;
            var query = _context.Products
                .AsQueryable()
                .Where(p=>p.IsDeleted==false);
            if (!string.IsNullOrEmpty(request.Search)) 
            {
                query = query.Where(p => EF.Functions.Like(p.Name,$"%{request.Search.Trim()}%"));

            }
            if (request.MaxPrice != null )
            {
                query = query.Where(p => p.SellingPrice <= request.MaxPrice);
            }
            if (request.MinPrice != null)
            {
                query = query.Where(p => p.SellingPrice >= request.MinPrice);
            }
            int totalCounts = await query.CountAsync();
            var products =  await query
                .OrderBy(p => p.Id)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p =>
                new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    SellingPrice = p.SellingPrice,
                    StockQuantity = p.StockQuantity,
                    CategoryName = p.Category.Name
                })
                .ToListAsync();

            PaginatedResponse < ProductDto > result = new PaginatedResponse<ProductDto>() {
                Data=products,
                PageNumber=request.PageNumber,
                PageSize=request.PageSize,
                TotalCount=totalCounts,
                TotalPages = (int)Math.Ceiling((double)totalCounts / (double)request.PageSize)
            };

            return result;
            
        }
    }
}
