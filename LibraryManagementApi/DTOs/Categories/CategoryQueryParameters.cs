namespace LibraryManagementApi.DTOs.Categories
{
    public class CategoryQueryParameters
    {
        public string? Search { get; set; }
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
