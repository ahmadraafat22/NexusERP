using MediatR;

namespace NexusERP.Application.Features.Customers.Commands.DeleteCustomer
{
    public class SoftDeleteCustomerCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public SoftDeleteCustomerCommand(Guid id)
        {
            Id = id;
        }
    }
}
