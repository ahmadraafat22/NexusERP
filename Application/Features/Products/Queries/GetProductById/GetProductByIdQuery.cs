using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
