using System.ComponentModel.DataAnnotations;

namespace LibraryManagementApi.DTOs.Auth
{
    public class LoginResponseDto
    {
        [Required]
        public string Token { get; set; } = string.Empty;
        [Required]
        public DateTime Expiration { get; set; }
    }
}
