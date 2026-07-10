using LibraryManagementApi.DTOs.Categories;
using LibraryManagementApi.Models;

namespace LibraryManagementApi.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll(CategoryQueryParameters categoryQueryParameters);
        Category? GetById(int id);
        Category Create(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}
