using MediatR;
namespace NexusERP.Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<ICollection<NexusERP.Domain.Entities.Customer>>
    {

    }
}
