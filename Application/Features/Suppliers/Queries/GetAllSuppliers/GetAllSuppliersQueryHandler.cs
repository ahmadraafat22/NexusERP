using MediatR;
using Microsoft.EntityFrameworkCore;
using NexusERP.Application.Common.CustomResponse;
using NexusERP.Application.Common.Extensions;
using NexusERP.Domain.Interfaces;

namespace NexusERP.Application.Features.Suppliers.Queries.GetAllSuppliers
{
    public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, PaginatedResponse<GetAllSuppliersDto>>
    {
        private readonly IAppDbContext _context;
        public GetAllSuppliersQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<PaginatedResponse<GetAllSuppliersDto>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Suppliers
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrEmpty(request.search))
            {
                var search = request.search.Trim();
                query = query.Where(s => EF.Functions.Like(s.Name, $"%{search}%") || EF.Functions.Like(s.PhoneNumber, $"%{search}%"));
            }

            return await query
                .OrderBy(s => s.Id)
                .Select(s => new GetAllSuppliersDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PhoneNumber = s.PhoneNumber,
                    Email = s.Email,
                    Address = s.Address
                }).ToPaginatedResponseAsync(request.pageNumber, request.pageSize, cancellationToken);
        }
    }
}
