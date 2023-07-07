namespace RetailCloud.Core.Specifications.Base
{
    public abstract class BaseSpecPrams
    {
        private const int MaxPageSize = 1000;

        public string? Sort { get; set; }
        public int Page { get; set; }

        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        private string? _search;

        public string? Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}