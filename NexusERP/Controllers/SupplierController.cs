using MediatR;
using Microsoft.AspNetCore.Mvc;
using NexusERP.Application.Features.Suppliers.Commands.CreateSupplier;
using NexusERP.Application.Features.Suppliers.Commands.SoftDeleteSupplier;
using NexusERP.Application.Features.Suppliers.Commands.UpdateSupplier;
using NexusERP.Application.Features.Suppliers.Queries.GetAllSuppliers;
using NexusERP.Application.Features.Suppliers.Queries.GetSupplierById;

namespace NexusERP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private IMediator _mediator;
        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateSupplier(CreateSupplierCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSuppliers([FromQuery] GetAllSuppliersQuery query)
        {
            var suppliers = await _mediator.Send(query);
            return Ok(suppliers);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetSupplierById(Guid id)
        {
            var supplier = await _mediator.Send(new GetSupplierByIdQuery(id));
            return Ok(supplier);
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateSupplier(Guid id, UpdateSupplierCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteSupplier(Guid id)
        {
            await _mediator.Send(new SoftDeleteSupplierCommand(id));
            return NoContent();
        }
    }
}
