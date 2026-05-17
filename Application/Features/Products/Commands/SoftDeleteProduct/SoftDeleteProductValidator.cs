using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusERP.Application.Features.Products.Commands.SoftDeleteProduct
{
    public class SoftDeleteProductValidator:AbstractValidator<SoftDeleteProductCommand>
    {
        public SoftDeleteProductValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Id is required");
        }
    }
}
