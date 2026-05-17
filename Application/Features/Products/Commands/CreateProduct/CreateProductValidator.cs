using FluentValidation;
using NexusERP.Application.Features.Products.commands.createProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusERP.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductValidator:AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.SKU)
                .NotEmpty();

            RuleFor(x => x.Barcode)
                .NotEmpty();

            RuleFor(x => x.CostPrice)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.SellingPrice)
                .GreaterThan(0);

            RuleFor(x => x.SellingPrice)
                .GreaterThanOrEqualTo(x=>x.CostPrice);

            RuleFor(x => x.CategoryId)
                .NotEmpty();

            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0);
        }
    }
}
