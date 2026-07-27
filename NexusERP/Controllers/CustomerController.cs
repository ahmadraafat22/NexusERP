using MediatR;
using Microsoft.AspNetCore.Mvc;
using NexusERP.Application.Features.Customers.Commands.CreateCustomer;
using NexusERP.Application.Features.Customers.Commands.DeleteCustomer;
using NexusERP.Application.Features.Customers.Commands.UpdateCustomer;
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
        public async Task<IActionResult> GetAllCustomers([FromQuery] GetAllCustomersQuery query)
        {
            var customers = await _mediator.Send(query);
            return Ok(customers);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery(id));
            return Ok(customer);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCusotmer(Guid id, UpdateCustomerCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            await _mediator.Send(new SoftDeleteCustomerCommand(id));
            return NoContent();
        }
    }
}
