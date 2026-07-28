using MediatR;
using NexusERP.Application.Common.CustomResponse;

namespace NexusERP.Application.Features.Suppliers.Queries.GetAllSuppliers
{
    public class GetAllSuppliersQuery : IRequest<PaginatedResponse<GetAllSuppliersDto>>
    {
        public string? search { get; set; }
        public int pageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 3;

    }
}
