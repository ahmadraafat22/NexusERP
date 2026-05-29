using MediatR;
using NexusERP.Application.Features.Products.Queries.GetProducts;
namespace NexusERP.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery:IRequest<ProductDto>
    {
        public Guid Id { get; set; }

        public GetProductByIdQuery(Guid id)
        {
            this.Id = id;
        }
    }
}
