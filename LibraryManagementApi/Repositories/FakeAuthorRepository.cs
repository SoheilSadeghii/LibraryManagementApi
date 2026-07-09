using LibraryManagementApi.Models;

namespace LibraryManagementApi.Repositories
{
    public class FakeAuthorRepository : IAuthorRepository
    {
        private readonly List<Author> _authors;
        public FakeAuthorRepository()
        {
            #region Seed Data

            _authors =
            [
                new Author { Id = 1, Fullname = "Robert Cecil Martin", Country = "USA" },
                new Author { Id = 2, Fullname = "Andy Hunt", Country = "USA" },
                new Author { Id = 3, Fullname = "Dave Thomas", Country = "USA" },
                new Author { Id = 4, Fullname = "Martin Fowler", Country = "UK" },
                new Author { Id = 5, Fullname = "Eric Evans", Country = "USA" },
                new Author { Id = 6, Fullname = "Kent Beck", Country = "USA" },
                new Author { Id = 7, Fullname = "John Doe", Country = "USA" },
                new Author { Id = 8, Fullname = "Jane Smith", Country = "Canada" },
                new Author { Id = 9, Fullname = "Michael Johnson", Country = "UK" },
                new Author { Id = 10, Fullname = "Sarah Williams", Country = "Australia" },
                new Author { Id = 11, Fullname = "David Brown", Country = "USA" },
                new Author { Id = 12, Fullname = "Emily Davis", Country = "USA" },
                new Author { Id = 13, Fullname = "Robert Wilson", Country = "UK" },
                new Author { Id = 14, Fullname = "Lisa Thompson", Country = "Canada" },
                new Author { Id = 15, Fullname = "James Anderson", Country = "Australia" },
                new Author { Id = 16, Fullname = "Maria Garcia", Country = "Spain" },
                new Author { Id = 17, Fullname = "Thomas Martinez", Country = "USA" },
                new Author { Id = 18, Fullname = "Jennifer Lee", Country = "USA" },
                new Author { Id = 19, Fullname = "Charles Wang", Country = "China" },
                new Author { Id = 20, Fullname = "Patricia Kim", Country = "South Korea" }
            ];

            #endregion
        }
        public IEnumerable<Author> GetAll()
        {
            return _authors.OrderBy(a => a.Id).ToList();
        }

        public Author? GetById(int id)
            => _authors.FirstOrDefault(a => a.Id == id);


        public Author Create(Author author)
        {
            var newId = _authors.Any() ? _authors.Max(a => a.Id) + 1 : 1;

            author.Id = newId;

            _authors.Add(author);

            return author;
        }

        public void Update(Author author)
        {
            var targetAuthor = _authors.FirstOrDefault(a => a.Id == author.Id);

            if (targetAuthor != null)
            {
                targetAuthor.Fullname = author.Fullname;
                targetAuthor.Country = author.Country;
            }
        }

        public void Delete(int id)
        {
            var author = _authors.FirstOrDefault(a => a.Id == id);

            if (author != null) _authors.Remove(author);
        }
    }
}
