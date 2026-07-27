using MediatR;
using NexusERP.Application.Common.CustomResponse;
namespace NexusERP.Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<PaginatedResponse<GetAllCustomersDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 3;
        public string? Search { get; set; }
    }
}
