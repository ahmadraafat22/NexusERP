using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusERP.Application.Features.Products.Queries.GetProducts
{
    public class GetAllProductsQuery:IRequest<List<ProductDto>>
    {
    }
}
