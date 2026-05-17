using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusERP.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand:IRequest<bool>
    {
        public Guid     Id              { get; set; }
        public string   Name            { get; set; }
        public decimal  SellingPrice    { get; set; }
        public int      StockQuantity   { get; set; }
        public Guid     CategoryId      { get; set; }

    }
}
