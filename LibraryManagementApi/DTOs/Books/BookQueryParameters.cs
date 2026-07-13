namespace LibraryManagementApi.DTOs.Books
{
    public class BookQueryParameters
    {
        private const int MaxPageSize = 100;
        private int _pageSize = 50;

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                if (value <= 0)
                {
                    _pageSize = 10;
                }
                else
                {
                    _pageSize = Math.Min(MaxPageSize, value);
                }
            }
        }

        public string? Search { get; set; }

        public int? AuthorId { get; set; }

        public int? CategoryId { get; set; }

        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }

        // Dynamic sort extension
        public string? SortBy { get; set; } = "Id";
        // asc - desc, default asc
        string _sortOrder = "asc";
        public string SortOrder
        {
            get => _sortOrder;
            set
            {
                if (value == "asc" || value == "desc")
                {
                    _sortOrder = value;
                }
            }
        }
    }
}
