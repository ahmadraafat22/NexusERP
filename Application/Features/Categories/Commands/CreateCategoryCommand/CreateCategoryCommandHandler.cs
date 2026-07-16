using MediatR;
using NexusERP.Domain.Interfaces;
using NexusERP.Domain.Entities;

namespace NexusERP.Application.Features.Categories.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly IAppDbContext _context;

        public CreateCategoryCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var  Category = new Category() 
            {
                Name=request.Name,
                Description=request.Description
            };
            // adding the category
            await _context.Categories.AddAsync(Category);
            // saving changes 
            await _context.SaveChangesAsync(cancellationToken);

            return Category.Id;

            
        }
    }
}
