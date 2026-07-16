using MediatR;
using Microsoft.EntityFrameworkCore;
using NexusERP.Domain.Interfaces;
using NexusERP.Application.Features.Categories.Queries.GetAllCategoriesQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusERP.Application.Features.Categories.Queries.GetCategoryById
{
    
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryById, GetCategoryDto>
    {
        private readonly IAppDbContext _context;

        public GetCategoryByIdHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<GetCategoryDto> Handle(GetCategoryById request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories
                .Where(c => c.Id == request.Id)
                .Select(c => new GetCategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                })
                .FirstOrDefaultAsync(cancellationToken);



            if (category == null)
            {
                throw new Exception("catgory cannot found!");
            }

            return category;
        }
    }
}
