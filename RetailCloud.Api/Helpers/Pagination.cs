using System.Collections.Generic;

namespace RetailCloud.Api.Helpers
{
    public class Pagination<T> where T : class
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 6;
        public int Count { get; set; }
        public int Total { get; set; }
        public IReadOnlyList<T> Data { get; set; }

        public Pagination(int page, int pageSize, int count, int total, IReadOnlyList<T> data)
        {
            Page = page;
            PageSize = pageSize;
            Count = count;
            Data = data;
            Total = total;
        }
    }
}