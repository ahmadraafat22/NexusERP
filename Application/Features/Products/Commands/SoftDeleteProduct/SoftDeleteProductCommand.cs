using MediatR;

namespace NexusERP.Application.Features.Products.Commands.SoftDeleteProduct
{
    public class SoftDeleteProductCommand:IRequest<bool>
    {
        public Guid Id { get; set; }

        public SoftDeleteProductCommand(Guid Id)
        {
            this.Id = Id;
        }
    }
}
