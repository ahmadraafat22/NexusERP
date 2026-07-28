using MediatR;

namespace NexusERP.Application.Features.Suppliers.Queries.GetSupplierById
{
    public class GetSupplierByIdQuery : IRequest<GetSupplierByIdDto>
    {
        public Guid Id { get; set; }
        public GetSupplierByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
