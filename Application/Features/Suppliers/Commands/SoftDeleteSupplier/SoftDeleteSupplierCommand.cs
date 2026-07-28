using MediatR;

namespace NexusERP.Application.Features.Suppliers.Commands.SoftDeleteSupplier
{
    public class SoftDeleteSupplierCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public SoftDeleteSupplierCommand(Guid id)
        {
            Id = id;
        }
    }
}
