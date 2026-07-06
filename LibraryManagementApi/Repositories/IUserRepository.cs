using LibraryManagementApi.Models;

namespace LibraryManagementApi.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User? GetById(int id);
        User? GetByUsername(string username);
        User? GetByEmail(string email);
        User Create(User user);
    }
}
