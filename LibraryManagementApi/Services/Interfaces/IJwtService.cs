using LibraryManagementApi.Models;

namespace LibraryManagementApi.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
