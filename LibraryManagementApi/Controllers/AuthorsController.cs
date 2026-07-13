using LibraryManagementApi.DTOs.Author;
using LibraryManagementApi.DTOs.Authors;
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
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository ??
                throw new ArgumentNullException();
        }

        [HttpGet]
        public IActionResult Get([FromQuery] AuthorQueryParameters authorQueryParameters)
        {
            var authors = 
                _authorRepository
                .GetAll(authorQueryParameters)
                .Select(b => new AuthorDto
                {
                    Id = b.Id,
                    Country = b.Country,
                    FullName = b.Fullname
                });

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var author = _authorRepository
                .GetById(id);

            if (author == null) return NotFound();

            var authorDto = new AuthorDto()
            {
                Id = author.Id,
                FullName = author.Fullname,
                Country = author.Country
            };

            return Ok(authorDto);
        }

        [HttpPost]
        public IActionResult Create(CreateAuthorDto createAuthorDto)
        {
            var createAuthor = new Author()
            {
                Fullname = createAuthorDto.Fullname,
                Country = createAuthorDto.Country
            };

            _authorRepository.Create(createAuthor);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createAuthor.Id },
                createAuthor);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateAuthorDto updateAuthorDto)
        {
            var author = _authorRepository
                .GetById(id);

            if (author == null) return NotFound();

            author.Fullname = updateAuthorDto.Fullname;
            author.Country = updateAuthorDto.Country;

            _authorRepository.Update(author);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult Update(int id, JsonPatchDocument<UpdateAuthorDto> patch)
        {
            var author = _authorRepository
                .GetById(id);

            if (author == null) return NotFound();

            var authorToPatch = new UpdateAuthorDto()
            {
                Fullname = author.Fullname,
                Country = author.Country
            };

            patch.ApplyTo(authorToPatch, ModelState);

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!TryValidateModel(authorToPatch)) return BadRequest(ModelState);

            author.Fullname = authorToPatch.Fullname;
            author.Country = authorToPatch.Country;

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var author = _authorRepository
                .GetById(id);

            if (author == null) return NotFound();

            _authorRepository.Delete(id);

            return NoContent();
        }
    }
}
