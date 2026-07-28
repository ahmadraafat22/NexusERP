using MediatR;

namespace NexusERP.Application.Features.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
