using LibraryManagementApi.Models;

namespace LibraryManagementApi.Repositories
{
    public class FakeBookRepository : IBookRepository
    {
        private readonly List<Book> _books;

        public FakeBookRepository()
        {
            _books =
            [
                new Book
                {
                    Id = 1,
                    Title = "Clean Code",
                    Description = "A Handbook of Agile Software Craftsmanship",
                    Year = 2008,
                    Price = 40,
                    AuthorId = 1,
                    CategoryId = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "The Pragmatic Programmer",
                    Description = "Programming best practices",
                    Year = 1999,
                    Price = 45,
                    AuthorId = 2,
                    CategoryId = 1
                }
            ];
        }

        public IEnumerable<Book> GetAll()
        {
            return _books.OrderBy(b => b.Id).ToList();
        }

        public Book? GetById(int id)
            => _books.FirstOrDefault(b => b.Id == id);
        

        public Book Create(Book book)
        {
            var newId = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;

            book.Id = newId;

            _books.Add(book);

            return book;
        }

        public void Update(Book book)
        {
            var targetBook = _books.FirstOrDefault(b => b.Id == book.Id);

            if (targetBook != null)
            {
                targetBook.Title = book.Title;
                targetBook.Description = book.Description;
                targetBook.Price = book.Price;
                targetBook.Year = book.Year;
                targetBook.AuthorId = book.AuthorId;
                targetBook.CategoryId = book.CategoryId;
            }
        }

        public void Delete(int id)
        {
            var book = _books.FirstOrDefault(a => a.Id == id);

            if (book != null) _books.Remove(book);
        }
    }
}
