using MediatR;
using NexusERP.Application.Common.CustomResponse;


namespace NexusERP.Application.Features.Categories.Queries.GetAllCategoriesQuery
{
    public class GetAllCategoryQuery:IRequest<PaginatedResponse<GetCategoryDto>>
    {
        public int      PageNumber  { get; set; } = 1;
        public int      PageSize    { get; set; } = 3;
        public string?  Search      { get; set; }
    }
}
