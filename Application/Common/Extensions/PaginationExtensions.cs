using Microsoft.EntityFrameworkCore;
using NexusERP.Application.Common.CustomResponse;

namespace NexusERP.Application.Common.Extensions
{
    public static class PaginationExtensions
    {
        public static async Task<PaginatedResponse<T>> ToPaginatedResponseAsync<T>(
            this IQueryable<T> query,
            int pageNumber,
            int pageSize,
            CancellationToken cancellationToken = default
            )
        {
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            if (pageSize > 50)
            {
                pageSize = 50;
            }
            var totalCount = await query.CountAsync(cancellationToken);

            var data = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).
                ToListAsync();

            return new PaginatedResponse<T>
            {
                Data = data,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
            };


        }
    }
}
