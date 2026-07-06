using LibraryManagementApi.Models;

namespace LibraryManagementApi.Repositories
{
    public class FakeUserRepository : IUserRepository
    {
        private readonly List<User> _users;
        public FakeUserRepository()
        {
            _users =
            [
                new User()
                {
                    Id = 1,
                    Username = "Admin",
                    PasswordHash = "admin123",
                    Email = "admin@gmail.com",
                    Role = "Admin"
                },
                new User()
                {
                    Id = 2,
                    Username = "soheil",
                    PasswordHash = "user123",
                    Email = "user@gmail.com",
                    Role = "User"
                }
            ];
        }
        public IEnumerable<User> GetAll()
            => _users.OrderBy(x => x.Id);

        public User? GetById(int id)
            => _users.FirstOrDefault(x => x.Id == id);

        public User? GetByUsername(string username)
            => _users.FirstOrDefault(x => x.Username == username);

        public User? GetByEmail(string email)
            => _users.FirstOrDefault(x => x.Email == email);

        public User Create(User user)
        {
            var newId = _users.Any() ? _users.Max(u => u.Id) + 1 : 1;

            user.Id = newId;

            _users.Add(user);

            return user;
        }
    }
}
