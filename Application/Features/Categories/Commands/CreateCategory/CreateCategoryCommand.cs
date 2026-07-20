using MediatR;
namespace NexusERP.Application.Features.Categories.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommand:IRequest<Guid>
    {
        public string   Name        { get; set; }
        public string?  Description { get; set; } = "";
    }
}
