using MediatR;

namespace NexusERP.Application.Features.Categories.Commands.SoftDeleteCategory
{
    public class SoftDeleteCategoryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public SoftDeleteCategoryCommand(Guid id)
        {
            Id = id;
        }
    }
}
