using MediatR;
using Microsoft.EntityFrameworkCore;
using NexusERP.Application.Common.CustomResponse;
using NexusERP.Domain.Interfaces;


namespace NexusERP.Application.Features.Categories.Queries.GetAllCategoriesQuery
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, PaginatedResponse<GetCategoryDto>>
    {
        private readonly IAppDbContext _context;

        public GetAllCategoryQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedResponse<GetCategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            if (request.PageNumber < 1)
                request.PageNumber = 1;
            if (request.PageSize > 50)
                request.PageSize = 50;
            var query = _context.Categories
                .AsQueryable();
            if (!string.IsNullOrEmpty(request.Search))
            {
                query = query.Where(p => EF.Functions.Like(p.Name, $"%{request.Search.Trim()}%"));

            }

            int totalCounts = await query.CountAsync();
            var categories = await query
                .OrderBy(c => c.Id)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(c =>
                new GetCategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                })
                .ToListAsync();

            PaginatedResponse<GetCategoryDto> result = new PaginatedResponse<GetCategoryDto>()
            {
                Data = categories,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = totalCounts,
                TotalPages = (int)Math.Ceiling((double)totalCounts / (double)request.PageSize)
            };

            return result;
        }
    }
}
