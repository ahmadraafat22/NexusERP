using MediatR;
using NexusERP.Application.Common.CustomResponse;

namespace NexusERP.Application.Features.Products.Queries.GetProducts
{
    public class GetAllProductsQuery:IRequest<PaginatedResponse<ProductDto>>
    {
        public int      PageNumber  { get; set; } = 1;
        public int      PageSize    { get; set; } = 3; 
        public string?  Search      { get; set; }
        public decimal? MaxPrice    { get; set; }
        public decimal? MinPrice    { get; set; }

    }
}
