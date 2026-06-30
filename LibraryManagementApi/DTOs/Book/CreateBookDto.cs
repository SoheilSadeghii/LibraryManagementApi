namespace LibraryManagementApi.DTOs.Book
{
    public class CreateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Year { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
