using MediatR;
using NexusERP.Application.Common.CustomResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusERP.Application.Features.Categories.Queries.GetAllCategoriesQuery
{
    public class GetAllCategoryQuery:IRequest<PaginatedResponse<GetCategoryDto>>
    {
        public int      PageNumber  { get; set; } = 1;
        public int      PageSize    { get; set; } = 3;
        public string?  Search      { get; set; }
    }
}
