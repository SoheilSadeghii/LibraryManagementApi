using LibraryManagementApi.DTOs.Book;
using LibraryManagementApi.Models;
using LibraryManagementApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository ??
                throw new ArgumentNullException();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var books =
                _bookRepository
                .GetAll()
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    AuthorId = b.AuthorId,
                    CategoryId = b.CategoryId,
                    Price = b.Price,
                    Year = b.Year
                });

            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _bookRepository.GetById(id);

            if (book == null) return NotFound();

            var bookDto = new BookDto()
            {
                Id = book.Id,
                Title = book.Title,
                Price = book.Price,
                Description = book.Description,
                Year = book.Year,
                CategoryId = book.CategoryId,
                AuthorId = book.AuthorId
            };

            return Ok(bookDto);
        }

        [HttpPost]
        public IActionResult Create(CreateBookDto bookDto)
        {
            var createdBook = new Book()
            {
                Title = bookDto.Title,
                Description = bookDto.Description,
                Year = bookDto.Year,
                Price = bookDto.Price,
                AuthorId = bookDto.AuthorId,
                CategoryId = bookDto.CategoryId
            };

            _bookRepository.Create(createdBook);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdBook.Id },
                createdBook);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, UpdateBookDto bookDto)
        {
            var targetBook = _bookRepository.GetById(id);

            if (targetBook == null) return NotFound();

            targetBook.Title = bookDto.Title;
            targetBook.Description = bookDto.Description;
            targetBook.Year = bookDto.Year;
            targetBook.Price = bookDto.Price;
            targetBook.AuthorId = bookDto.AuthorId;
            targetBook.CategoryId = bookDto.CategoryId;

            _bookRepository.Update(targetBook);

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public IActionResult Update(int id, JsonPatchDocument<UpdateBookDto> patch)
        {
            var targetBook = _bookRepository.GetById(id);

            if (targetBook == null) return NotFound();

            var bookToPatch = new UpdateBookDto()
            {
                Title = targetBook.Title,
                Description = targetBook.Description,
                Year = targetBook.Year,
                Price = targetBook.Price,
                AuthorId = targetBook.AuthorId,
                CategoryId = targetBook.CategoryId
            };

            if (patch == null) return BadRequest();

            patch.ApplyTo(bookToPatch, ModelState);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!TryValidateModel(bookToPatch)) return BadRequest(ModelState);

            targetBook.Title = bookToPatch.Title;
            targetBook.Description = bookToPatch.Description;
            targetBook.Year = bookToPatch.Year;
            targetBook.Price = bookToPatch.Price;
            targetBook.AuthorId = bookToPatch.AuthorId;
            targetBook.CategoryId = bookToPatch.CategoryId;

            _bookRepository.Update(targetBook);

            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook(int id)
        {
            var targetBook = _bookRepository.GetById(id);

            if (targetBook == null) return NotFound();

            _bookRepository.Delete(id);

            return NoContent();
        }
    }
}
