using MediatR;
using Microsoft.EntityFrameworkCore;
using NexusERP.Application.Features.Customers.Queries.GetAllCustomers;
using NexusERP.Domain.Interfaces;

namespace NexusERP.Application.Features.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, ICollection<Domain.Entities.Customer>>
    {
        private readonly IAppDbContext _context;
        public GetAllCustomersQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Domain.Entities.Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _context.Customers.AsNoTracking().ToListAsync();
            return customers;
        }
    }
}
