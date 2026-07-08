using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApi.DTOs.Category
{
    public class UpdateCategoryDto
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;
    }
}
