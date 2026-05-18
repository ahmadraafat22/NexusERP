using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusERP.Application.Features.Categories.Queries.GetAllCategoriesQuery
{
    public class GetCategoryDto
    {
        public Guid     Id          { get; set; }
        public string   Name        { get; set; }
        public string?  Description { get; set; }
    }
}
