using LibraryManagementApi.DTOs.Authors;
using LibraryManagementApi.Models;

namespace LibraryManagementApi.Repositories
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll(AuthorQueryParameters authorQueryParameters);
        Author? GetById(int id);
        Author Create(Author author);
        void Update(Author author);
        void Delete(int id);
    }
}
