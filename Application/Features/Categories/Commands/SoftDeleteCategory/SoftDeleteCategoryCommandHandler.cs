using MediatR;
using NexusERP.Application.Common.Exceptions;
using NexusERP.Domain.Interfaces;

namespace NexusERP.Application.Features.Categories.Commands.SoftDeleteCategory
{
    public class SoftDeleteCategoryCommandHandler : IRequestHandler<SoftDeleteCategoryCommand, bool>
    {
        private readonly IAppDbContext _context;
        public SoftDeleteCategoryCommandHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(SoftDeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(request.Id, cancellationToken);
            if (category == null)
            {
                throw new NotFoundException(nameof(request), request.Id);
            }
            if (category.IsDeleted)
            {
                throw new Exception($"this {nameof(request)} already deleted!");
            }
            category.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
