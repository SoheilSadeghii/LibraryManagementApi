using LibraryManagementApi.Models;

namespace LibraryManagementApi.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category? GetById(int id);
        Category Create(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}
