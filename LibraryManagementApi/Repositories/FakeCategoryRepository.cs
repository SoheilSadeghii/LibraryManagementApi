using LibraryManagementApi.DTOs.Books;
using LibraryManagementApi.DTOs.Categories;
using LibraryManagementApi.Models;
using System.Reflection;
using LibraryManagementApi.Extensions;

namespace LibraryManagementApi.Repositories
{
    public class FakeCategoryRepository : ICategoryRepository
    {
        private readonly List<Category> _categories;
        public FakeCategoryRepository()
        {
            #region Seed Data

            _categories =
            [
                new Category { Id = 1, Name = "Computer & Technology" },
                new Category { Id = 2, Name = "Programming" },
                new Category { Id = 3, Name = "Software Engineering" },
                new Category { Id = 4, Name = "Data Science" },
                new Category { Id = 5, Name = "Artificial Intelligence" },
                new Category { Id = 6, Name = "Web Development" },
                new Category { Id = 7, Name = "Mobile Development" },
                new Category { Id = 8, Name = "Database Management" },
                new Category { Id = 9, Name = "DevOps" },
                new Category { Id = 10, Name = "Cloud Computing" },
                new Category { Id = 11, Name = "Cybersecurity" },
                new Category { Id = 12, Name = "Computer Science Theory" },
                new Category { Id = 13, Name = "User Experience" },
                new Category { Id = 14, Name = "Project Management" },
                new Category { Id = 15, Name = "Business & Management" }
            ];

            #endregion
        }
        public IEnumerable<Category> GetAll(CategoryQueryParameters categoryQueryParameters)
        {
            var categories = _categories.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(categoryQueryParameters.Search))
            {
                var searchTerm =
                    categoryQueryParameters.Search.Trim();

                categories = categories
                    .Where(c => c.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(categoryQueryParameters.SortBy))
            {
                var bookQueryable = categories.AsQueryable();

                if (typeof(Category).GetProperty(categoryQueryParameters.SortBy,
                    BindingFlags.Public |
                    BindingFlags.Instance |
                    BindingFlags.IgnoreCase) != null)
                {
                    categories = bookQueryable.orderByCustom(
                        categoryQueryParameters.SortBy,
                        categoryQueryParameters.SortOrder
                        );
                }
            }

            return categories;
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
