using MediatR;
using Microsoft.AspNetCore.Mvc;
using NexusERP.Application.Features.Customers.Commands.CreateCustomer;
using NexusERP.Application.Features.Customers.Queries.GetAllCustomers;
using NexusERP.Application.Features.Customers.Queries.GetById;

namespace NexusERP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerCommand command)
        {
            var Id = await _mediator.Send(command);
            return Ok(Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _mediator.Send(new GetAllCustomersQuery());
            return Ok(customers);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery(id));
            return Ok(customer);
        }
    }
}
