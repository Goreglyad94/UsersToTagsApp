using Microsoft.EntityFrameworkCore;

namespace UsersToTagsApp.Core.DataGateways.Extentions
{
    public static class PagedListQueryableExtensions
    {
        public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source,
            int page,
            int size,
            CancellationToken token = default)
        {
            var count = await source.CountAsync(token);

            if (count == 0)
                return new(Enumerable.Empty<T>(), 0, 0, 0);

            var pagedItems = await source.Skip((page - 1) * size)
                    .Take(size)
                    .ToListAsync(token);

            return new PagedList<T>(pagedItems, count, page, size);
        }
    }
}