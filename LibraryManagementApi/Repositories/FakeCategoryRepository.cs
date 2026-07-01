using LibraryManagementApi.Models;

namespace LibraryManagementApi.Repositories
{
    public class FakeCategoryRepository : ICategoryRepository
    {
        private readonly List<Category> _categories;
        public FakeCategoryRepository()
        {
            _categories =
            [
                new Category
                {
                    Id = 1,
                    Name = "Computer & Technology"
                }
            ];
        }
        public IEnumerable<Category> GetAll()
        {
            return _categories.OrderBy(c => c.Id).ToList();
        }

        public Category? GetById(int id)
            => _categories.FirstOrDefault(c => c.Id == id);

        public Category Create(Category category)
        {
            var newId = _categories.Any() ? _categories.Max(c => c.Id) + 1 : 1;

            category.Id = newId;

            _categories.Add(category);

            return category;
        }

        public void Update(Category category)
        {
            var targetCategory = _categories.FirstOrDefault(c => c.Id == category.Id);

            if (targetCategory != null) targetCategory.Name = category.Name;
        }

        public void Delete(int id)
        {
            var tartgetCategory = _categories.FirstOrDefault(c => c.Id == id);

            _categories.Remove(tartgetCategory);
        }
    }
}
