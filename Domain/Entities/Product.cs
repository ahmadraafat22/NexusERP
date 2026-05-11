using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusERP.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string SKU { get; set; }
        public string  Barcode { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int StockQuantity { get; set; }
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
