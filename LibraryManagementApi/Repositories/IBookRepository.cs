using LibraryManagementApi.Models;

namespace LibraryManagementApi.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book? GetById(int id);
        Book Create(Book book);
        void Update(Book book);
        void Delete(int id);
    }
}
