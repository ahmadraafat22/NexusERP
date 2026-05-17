using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens.Experimental;
using NexusERP.Application.Abstractions;
using NexusERP.Application.Common.CustomResponse;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

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
                .AsQueryable();
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
                TotalCount=totalCounts
            };

            return result;
            
        }
    }
}
