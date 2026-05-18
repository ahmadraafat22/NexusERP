using MediatR;
using NexusERP.Application.Features.Categories.Queries.GetAllCategoriesQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusERP.Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryById:IRequest<GetCategoryDto>
    {
        public Guid Id { get; set; }
        public GetCategoryById(Guid Id)
        {
            this.Id = Id;            
        }
    }
}
