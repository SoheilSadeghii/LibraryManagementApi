using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApi.DTOs.Author
{
    public class CreateAuthorDto
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Fullname { get; set; } = string.Empty;
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Country { get; set; } = string.Empty;
    }
}
