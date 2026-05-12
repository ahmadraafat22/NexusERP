using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusERP.Application.Features.Products.Queries.GetProducts
{
    public class ProductDto
    {
        public  Guid    Id              { get; set; }
        public string   Name            { get; set; }
        public string   Description     { get; set; }
        public decimal  SellingPrice    { get; set; }
        public int      StockQuantity   { get; set; }
        public string   CategoryName    { get; set; }
    }
}
