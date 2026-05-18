using MediatR;
using Microsoft.AspNetCore.Mvc;
using NexusERP.Application.Features.Products.commands.createProduct;
using NexusERP.Application.Features.Products.Commands.SoftDeleteProduct;
using NexusERP.Application.Features.Products.Commands.UpdateProduct;
using NexusERP.Application.Features.Products.Queries.GetProductById;
using NexusERP.Application.Features.Products.Queries.GetProducts;

namespace NexusERP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateProductCommand command) 
        {
            var Id = await _mediator.Send(command);

            return Ok(Id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetAllProductsQuery query)
        {
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpGet("{Id:guid}")]
        public async Task<IActionResult> GetProductById(Guid Id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(Id));
            return Ok(product);
        }

        [HttpPut("{Id:guid}")]
        public async Task<IActionResult> UpdateProduct(Guid Id , [FromBody]UpdateProductCommand command)
        {
            if(Id!=command.Id)
            {
                return BadRequest("Id mismatched");
            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{Id:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid Id) 
        {
            await _mediator.Send(new SoftDeleteProductCommand (Id));

            return NoContent();
        }
    }
}
