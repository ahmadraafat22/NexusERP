using MediatR;
using NexusERP.Application.Common.Exceptions;
using NexusERP.Domain.Entities;
using NexusERP.Domain.Interfaces;

namespace NexusERP.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly IAppDbContext _context;
        public UpdateCategoryCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (category == null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }
            if (category.IsDeleted)
            {
                throw new Exception($"this {nameof(request)} already deleted!");
            }
            // mapping new data 
            category.Name = request.Name;
            category.Description = request.Description;
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
