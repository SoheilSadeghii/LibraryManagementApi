using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApi.DTOs.Book
{
    public class CreateBookDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Title { get; set; } = string.Empty;
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        [Range(1800, 2100)]
        public int Year { get; set; }
        [Range(0.01, 100000)]
        public decimal Price { get; set; }
        [Range(1, int.MaxValue)]
        public int AuthorId { get; set; }
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }
    }
}
