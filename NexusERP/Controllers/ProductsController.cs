using MediatR;
using Microsoft.AspNetCore.Mvc;
using NexusERP.Application.Features.Products.commands.createProduct;
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
        public async Task<IActionResult> Create(CreateProductCommand command) 
        {
            var Id = await _mediator.Send(command);

            return CreatedAtAction("",Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }
    }
}
