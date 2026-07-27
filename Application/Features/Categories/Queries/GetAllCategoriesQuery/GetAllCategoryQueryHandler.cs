using MediatR;
using Microsoft.EntityFrameworkCore;
using NexusERP.Application.Common.CustomResponse;
using NexusERP.Application.Common.Extensions;
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

            var query = _context.Categories.AsNoTracking()
                .AsQueryable();
            if (!string.IsNullOrEmpty(request.Search))
            {
                var search = request.Search.Trim();
                query = query.Where(p => EF.Functions.Like(p.Name, $"%{search}%"));

            }


            return await query
                .OrderBy(c => c.Id)
                .Select(c =>
                new GetCategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                })
                .ToPaginatedResponseAsync(request.PageNumber, request.PageSize, cancellationToken);




        }
    }
}
