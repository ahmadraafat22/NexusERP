using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace NexusERP.Application.Features.Products.Commands.SoftDeleteProduct
{
    public class SoftDelelteProductCommand:IRequest<bool>
    {
        public Guid Id { get; set; }

        public SoftDelelteProductCommand(Guid Id)
        {
            this.Id = Id;
        }
    }
}
