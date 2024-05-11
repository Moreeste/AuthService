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
        
        public int Page { get; }
        public int PageSize { get; }
        public int TotalItems { get; }
        public int TotalPages => (int)Math.Ceiling((double)TotalItems / PageSize);
        public bool HasNextPage => Page * PageSize < TotalItems;
        public bool HasPreviousPage => Page > 1;
        public List<T>? Items { get; }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> query, int page, int pageSize)
        {
            var totalItems = await query.CountAsync();
            var startIndex = (page - 1) * pageSize;
            var items = await query.Skip(startIndex).Take(pageSize).ToListAsync();

            return new(items, page, pageSize, totalItems);
        }

        public static PagedList<T> Create(IEnumerable<T> list, int page, int pageSize)
        {
            var totalItems = list.Count();
            var startIndex = (page - 1) * pageSize;
            var items = list.Skip(startIndex).Take(pageSize).ToList();

            return new(items, page, pageSize, totalItems);
        }
    }
}
