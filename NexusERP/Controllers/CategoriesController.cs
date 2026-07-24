using MediatR;
using Microsoft.AspNetCore.Mvc;
using NexusERP.Application.Features.Categories.Commands.CreateCategoryCommand;
using NexusERP.Application.Features.Categories.Commands.SoftDeleteCategory;
using NexusERP.Application.Features.Categories.Commands.UpdateCategory;
using NexusERP.Application.Features.Categories.Queries.GetAllCategoriesQuery;
using NexusERP.Application.Features.Categories.Queries.GetCategoryById;
namespace NexusERP.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            var Id = await _mediator.Send(command);
            return Ok(Id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories([FromQuery] GetAllCategoryQuery query)
        {
            var allCategories = await _mediator.Send(query);

            return Ok(allCategories);
        }

        [HttpGet("{Id:guid}")]
        public async Task<IActionResult> GetCategoryById(Guid Id)
        {
            var category = await _mediator.Send(new GetCategoryById(Id));

            return Ok(category);
        }
        [HttpPut("{Id:guid}")]
        public async Task<IActionResult> UpdateCategory(Guid Id, UpdateCategoryCommand command)
        {
            command.Id = Id;
            await _mediator.Send(command);
            return NoContent();
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            await _mediator.Send(new SoftDeleteCategoryCommand(id));
            return NoContent();
        }
    }
}
