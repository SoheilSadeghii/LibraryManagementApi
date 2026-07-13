using LibraryManagementApi.DTOs.Books;
using LibraryManagementApi.Extensions;
using LibraryManagementApi.Models;
using System.Reflection;

namespace LibraryManagementApi.Repositories
{
    public class FakeBookRepository : IBookRepository
    {
        private readonly List<Book> _books;

        public FakeBookRepository()
        {
            #region Seed Data

            _books =
            [
                // Computer & Technology (Category 1)
                new Book { Id = 1, Title = "Clean Code", Description = "A Handbook of Agile Software Craftsmanship", Year = 2008, Price = 40, AuthorId = 1, CategoryId = 1 },
                new Book { Id = 2, Title = "The Pragmatic Programmer", Description = "Programming best practices for modern developers", Year = 1999, Price = 45, AuthorId = 2, CategoryId = 1 },
                new Book { Id = 3, Title = "The Art of Computer Programming", Description = "Fundamental algorithms and data structures", Year = 1997, Price = 70, AuthorId = 7, CategoryId = 1 },
                new Book { Id = 4, Title = "Code Complete", Description = "Practical software construction techniques", Year = 2004, Price = 50, AuthorId = 3, CategoryId = 1 },
                
                // Programming (Category 2)
                new Book { Id = 5, Title = "Head First Design Patterns", Description = "Object-oriented design patterns explained", Year = 2004, Price = 55, AuthorId = 4, CategoryId = 2 },
                new Book { Id = 6, Title = "Effective Java", Description = "Best practices for Java programming", Year = 2018, Price = 50, AuthorId = 8, CategoryId = 2 },
                new Book { Id = 7, Title = "Python Crash Course", Description = "Hands-on Python programming", Year = 2019, Price = 35, AuthorId = 9, CategoryId = 2 },
                new Book { Id = 8, Title = "JavaScript: The Good Parts", Description = "Essential JavaScript techniques", Year = 2008, Price = 30, AuthorId = 10, CategoryId = 2 },
                
                // Software Engineering (Category 3)
                new Book { Id = 9, Title = "Software Engineering", Description = "Comprehensive software engineering guide", Year = 2015, Price = 65, AuthorId = 5, CategoryId = 3 },
                new Book { Id = 10, Title = "Refactoring", Description = "Improving the design of existing code", Year = 2018, Price = 55, AuthorId = 4, CategoryId = 3 },
                new Book { Id = 11, Title = "Test Driven Development", Description = "By example development process", Year = 2002, Price = 45, AuthorId = 6, CategoryId = 3 },
                new Book { Id = 12, Title = "Extreme Programming", Description = "Agile development methodology", Year = 2004, Price = 40, AuthorId = 6, CategoryId = 3 },
                
                // Data Science (Category 4)
                new Book { Id = 13, Title = "Data Science for Business", Description = "Data-driven decision making", Year = 2013, Price = 60, AuthorId = 11, CategoryId = 4 },
                new Book { Id = 14, Title = "Python for Data Analysis", Description = "Data analysis with Pandas, NumPy", Year = 2017, Price = 50, AuthorId = 12, CategoryId = 4 },
                new Book { Id = 15, Title = "R for Data Science", Description = "Statistical analysis with R", Year = 2016, Price = 45, AuthorId = 13, CategoryId = 4 },
                new Book { Id = 16, Title = "Statistical Learning", Description = "Machine learning fundamentals", Year = 2013, Price = 55, AuthorId = 14, CategoryId = 4 },
                
                // Artificial Intelligence (Category 5)
                new Book { Id = 17, Title = "Artificial Intelligence: A Modern Approach", Description = "Comprehensive AI textbook", Year = 2016, Price = 80, AuthorId = 15, CategoryId = 5 },
                new Book { Id = 18, Title = "Machine Learning Yearning", Description = "Practical ML techniques", Year = 2018, Price = 30, AuthorId = 16, CategoryId = 5 },
                new Book { Id = 19, Title = "Deep Learning", Description = "Neural networks and deep learning", Year = 2016, Price = 70, AuthorId = 17, CategoryId = 5 },
                new Book { Id = 20, Title = "Pattern Recognition", Description = "Statistical pattern recognition", Year = 2006, Price = 65, AuthorId = 18, CategoryId = 5 },
                
                // Web Development (Category 6)
                new Book { Id = 21, Title = "You Don't Know JS", Description = "Deep dive into JavaScript", Year = 2019, Price = 40, AuthorId = 19, CategoryId = 6 },
                new Book { Id = 22, Title = "HTML and CSS Design", Description = "Responsive web design techniques", Year = 2017, Price = 35, AuthorId = 20, CategoryId = 6 },
                new Book { Id = 23, Title = "React: The Complete Guide", Description = "Master React.js development", Year = 2020, Price = 50, AuthorId = 3, CategoryId = 6 },
                new Book { Id = 24, Title = "Angular Development", Description = "Advanced Angular techniques", Year = 2019, Price = 48, AuthorId = 8, CategoryId = 6 },
                
                // Mobile Development (Category 7)
                new Book { Id = 25, Title = "iOS Programming", Description = "Swift and iOS development", Year = 2020, Price = 55, AuthorId = 9, CategoryId = 7 },
                new Book { Id = 26, Title = "Android Development", Description = "Kotlin and Android programming", Year = 2019, Price = 52, AuthorId = 10, CategoryId = 7 },
                new Book { Id = 27, Title = "Cross-Platform Development", Description = "React Native and Flutter", Year = 2020, Price = 45, AuthorId = 11, CategoryId = 7 },
                new Book { Id = 28, Title = "Mobile UX Design", Description = "User experience for mobile", Year = 2018, Price = 40, AuthorId = 12, CategoryId = 7 },
                
                // Database Management (Category 8)
                new Book { Id = 29, Title = "Database System Concepts", Description = "Database design and management", Year = 2019, Price = 75, AuthorId = 13, CategoryId = 8 },
                new Book { Id = 30, Title = "SQL Performance Explained", Description = "Database optimization techniques", Year = 2012, Price = 35, AuthorId = 14, CategoryId = 8 },
                new Book { Id = 31, Title = "MongoDB: The Definitive Guide", Description = "NoSQL database mastery", Year = 2019, Price = 50, AuthorId = 15, CategoryId = 8 },
                new Book { Id = 32, Title = "PostgreSQL Advanced", Description = "Advanced PostgreSQL features", Year = 2018, Price = 45, AuthorId = 16, CategoryId = 8 },
                
                // DevOps (Category 9)
                new Book { Id = 33, Title = "The DevOps Handbook", Description = "DevOps culture and practices", Year = 2016, Price = 45, AuthorId = 17, CategoryId = 9 },
                new Book { Id = 34, Title = "Docker Deep Dive", Description = "Containerization with Docker", Year = 2020, Price = 40, AuthorId = 18, CategoryId = 9 },
                new Book { Id = 35, Title = "Kubernetes Up & Running", Description = "Kubernetes orchestration", Year = 2019, Price = 55, AuthorId = 19, CategoryId = 9 },
                new Book { Id = 36, Title = "Continuous Delivery", Description = "Release software automatically", Year = 2010, Price = 50, AuthorId = 20, CategoryId = 9 },
                
                // Cloud Computing (Category 10)
                new Book { Id = 37, Title = "AWS Certified Solutions Architect", Description = "AWS cloud architecture", Year = 2020, Price = 60, AuthorId = 1, CategoryId = 10 },
                new Book { Id = 38, Title = "Google Cloud Platform", Description = "GCP cloud services", Year = 2019, Price = 55, AuthorId = 2, CategoryId = 10 },
                new Book { Id = 39, Title = "Microsoft Azure Essentials", Description = "Azure cloud computing", Year = 2019, Price = 50, AuthorId = 3, CategoryId = 10 },
                new Book { Id = 40, Title = "Cloud Native Patterns", Description = "Cloud-native application design", Year = 2020, Price = 48, AuthorId = 4, CategoryId = 10 },
                
                // Cybersecurity (Category 11)
                new Book { Id = 41, Title = "Cybersecurity Essentials", Description = "Basic security practices", Year = 2018, Price = 45, AuthorId = 5, CategoryId = 11 },
                new Book { Id = 42, Title = "Penetration Testing", Description = "Ethical hacking techniques", Year = 2020, Price = 60, AuthorId = 6, CategoryId = 11 },
                new Book { Id = 43, Title = "Cryptography Engineering", Description = "Applied cryptography", Year = 2010, Price = 65, AuthorId = 7, CategoryId = 11 },
                new Book { Id = 44, Title = "Web Application Security", Description = "Securing web applications", Year = 2018, Price = 50, AuthorId = 8, CategoryId = 11 },
                
                // Computer Science Theory (Category 12)
                new Book { Id = 45, Title = "Introduction to Algorithms", Description = "Algorithms and data structures", Year = 2009, Price = 85, AuthorId = 9, CategoryId = 12 },
                new Book { Id = 46, Title = "The Theory of Computation", Description = "Computational theory fundamentals", Year = 2006, Price = 70, AuthorId = 10, CategoryId = 12 },
                new Book { Id = 47, Title = "Discrete Mathematics", Description = "Mathematics for computer science", Year = 2012, Price = 55, AuthorId = 11, CategoryId = 12 },
                new Book { Id = 48, Title = "Programming Language Concepts", Description = "Programming language theory", Year = 2015, Price = 60, AuthorId = 12, CategoryId = 12 },
                
                // User Experience (Category 13)
                new Book { Id = 49, Title = "Don't Make Me Think", Description = "Web usability principles", Year = 2014, Price = 35, AuthorId = 13, CategoryId = 13 },
                new Book { Id = 50, Title = "The Design of Everyday Things", Description = "UX design principles", Year = 2013, Price = 40, AuthorId = 14, CategoryId = 13 },
                new Book { Id = 51, Title = "UX Strategy", Description = "User experience planning", Year = 2012, Price = 45, AuthorId = 15, CategoryId = 13 },
                new Book { Id = 52, Title = "Mobile UX Design", Description = "Mobile user experience", Year = 2017, Price = 38, AuthorId = 16, CategoryId = 13 },
                
                // Project Management (Category 14)
                new Book { Id = 53, Title = "The Phoenix Project", Description = "IT project management novel", Year = 2013, Price = 30, AuthorId = 17, CategoryId = 14 },
                new Book { Id = 54, Title = "Agile Project Management", Description = "Agile methodology", Year = 2018, Price = 42, AuthorId = 18, CategoryId = 14 },
                new Book { Id = 55, Title = "Project Management Professional", Description = "PMP certification guide", Year = 2017, Price = 55, AuthorId = 19, CategoryId = 14 },
                new Book { Id = 56, Title = "Scrum: The Art of Doing Twice", Description = "Scrum framework explained", Year = 2014, Price = 35, AuthorId = 20, CategoryId = 14 },
                
                // Business & Management (Category 15)
                new Book { Id = 57, Title = "The Lean Startup", Description = "Startup methodology", Year = 2011, Price = 30, AuthorId = 1, CategoryId = 15 },
                new Book { Id = 58, Title = "Zero to One", Description = "Startup building strategies", Year = 2014, Price = 28, AuthorId = 2, CategoryId = 15 },
                new Book { Id = 59, Title = "Good to Great", Description = "Business excellence", Year = 2001, Price = 25, AuthorId = 3, CategoryId = 15 },
                new Book { Id = 60, Title = "The Innovator's Dilemma", Description = "Business innovation", Year = 1997, Price = 30, AuthorId = 4, CategoryId = 15 }
            ];

            #endregion
        }

        public IEnumerable<Book> GetAll(BookQueryParameters bookQueryParameters)
        {
            var books = _books.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(bookQueryParameters.Search))
            {
                var searchTerm =
                    bookQueryParameters.Search.Trim();

                books = books
                    .Where(p => p.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                    p.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
            }

            if (bookQueryParameters.AuthorId != null)
            {
                books = books
                    .Where(b => b.AuthorId == bookQueryParameters.AuthorId);
            }

            if (bookQueryParameters.CategoryId != null)
            {
                books = books
                    .Where(b => b.CategoryId == bookQueryParameters.CategoryId);
            }

            if (bookQueryParameters.MinPrice != null)
            {
                books = books
                    .Where(b => b.Price >= bookQueryParameters.MinPrice);
            }

            if (bookQueryParameters.MaxPrice != null)
            {
                books = books
                    .Where(b => b.Price <= bookQueryParameters.MaxPrice);
            }

            if (!string.IsNullOrWhiteSpace(bookQueryParameters.SortBy))
            {
                var bookQueryable = books.AsQueryable();

                if (typeof(Book).GetProperty(bookQueryParameters.SortBy,
                    BindingFlags.Public |
                    BindingFlags.Instance |
                    BindingFlags.IgnoreCase) != null)
                {
                    books = bookQueryable.orderByCustom(
                        bookQueryParameters.SortBy,
                        bookQueryParameters.SortOrder
                        );
                }
            }

            books = books
                .Skip(bookQueryParameters.PageSize * (bookQueryParameters.PageNumber - 1))
                .Take(bookQueryParameters.PageSize);

            return books;
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
