using MediatR;

namespace NexusERP.Application.Features.Customers.Queries.GetById
{
    public class GetCustomerByIdQuery : IRequest<GetCustomerDto>
    {
        public Guid Id { get; set; }
        public GetCustomerByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
