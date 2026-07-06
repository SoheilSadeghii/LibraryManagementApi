using LibraryManagementApi.Models;

namespace LibraryManagementApi.Repositories
{
    public class FakeAuthorRepository : IAuthorRepository
    {
        private readonly List<Author> _authors;
        public FakeAuthorRepository()
        {
            _authors =
            [
                new Author
                {
                    Id = 1,
                    Fullname = "Robert Cecil Martin",
                    Country = "USA"
                },
                new Author
                {
                    Id = 2,
                    Fullname = " Andy Hunt",
                    Country = "USA"
                }
            ];
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
