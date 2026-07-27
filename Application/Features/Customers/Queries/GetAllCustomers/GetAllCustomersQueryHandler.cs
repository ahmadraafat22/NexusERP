using MediatR;
using Microsoft.EntityFrameworkCore;
using NexusERP.Application.Common.CustomResponse;
using NexusERP.Application.Common.Extensions;
using NexusERP.Application.Features.Customers.Queries.GetAllCustomers;
using NexusERP.Domain.Interfaces;

namespace NexusERP.Application.Features.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, PaginatedResponse<GetAllCustomersDto>>
    {
        private readonly IAppDbContext _context;
        public GetAllCustomersQueryHandler(IAppDbContext context)
        {
            _context = context;
        }

        async Task<PaginatedResponse<GetAllCustomersDto>> IRequestHandler<GetAllCustomersQuery, PaginatedResponse<GetAllCustomersDto>>.Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Customers
                .AsNoTracking()
                .AsQueryable();
            if (!string.IsNullOrEmpty(request.Search))
            {
                var search = request.Search.Trim();
                query = query.Where(c => EF.Functions.Like(c.Name, $"%{search}%") || EF.Functions.Like(c.PhoneNumber, $"%{search}%"));
            }

            return await query.OrderBy(c => c.Id)
                .Select(c =>
                    new GetAllCustomersDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        PhoneNumber = c.PhoneNumber,
                        Email = c.Email,
                        Address = c.Address,
                        Code = c.Code
                    }
                ).ToPaginatedResponseAsync(request.PageNumber, request.PageSize, cancellationToken);

        }
    }
}
