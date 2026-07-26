using MediatR;
using Microsoft.EntityFrameworkCore;
using NexusERP.Application.Common.Exceptions;
using NexusERP.Domain.Interfaces;

namespace NexusERP.Application.Features.Customers.Queries.GetById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, GetCustomerDto>
    {
        private readonly IAppDbContext _context;
        public GetCustomerByIdQueryHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<GetCustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == request.Id);
            if (customer == null)
            {
                throw new NotFoundException(nameof(customer), request);
            }
            GetCustomerDto customerDto = new GetCustomerDto
            {
                Name = customer.Name,
                PhoneNumber = customer.PhoneNumber,
                Code = customer.Code,
                Email = customer.Email,
                Address = customer.Address
            };
            return customerDto;
        }
    }
}
