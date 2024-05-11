using Microsoft.EntityFrameworkCore;

namespace Domain.Utilities
{
    public class PagedList<T>
    {
        private PagedList(List<T> items, int page, int pageSize, int totalItems)
        {
            Items = items;
            Page = page;
            PageSize = pageSize;
            TotalItems = totalItems;
        }

        public List<T>? Items { get; set; }
        public int Page { get; }
        public int PageSize { get; }
        public int TotalItems { get; }
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
        public bool HasNextPage => Page * PageSize < TotalItems;
        public bool HasPreviousPage => Page > 1;

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> query, int page, int pageSize)
        {
            var totalItems = await query.CountAsync();
            var startIndex = (page - 1) * pageSize;
            var items = await query.Skip(startIndex).Take(pageSize).ToListAsync();

            return new(items, page, pageSize, totalItems);
        }
    }
}
