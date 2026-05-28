using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexusERP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusERP.Infrasructure.Persistence.Configurations
{
    public class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
            builder.HasIndex(p => p.Barcode).IsUnique();
            builder.HasIndex(p => p.SKU)
                .IsUnique();
            builder.Property(p => p.SKU).IsRequired();
            builder.Property(p => p.Barcode).IsRequired();
            builder.Property(p => p.SellingPrice).HasPrecision(18, 2);
            builder.Property(p => p.CostPrice).HasPrecision(18, 2);
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);
            builder.Property(p => p.StockQuantity).IsRequired();
            builder.HasCheckConstraint(
                    "CK_Product_StockQuantity",
                    "[StockQuantity]>=0"
                );

        }
    }
}
