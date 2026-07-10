using LibraryManagementApi.DTOs.Categories;
using LibraryManagementApi.DTOs.Category;
using LibraryManagementApi.Models;
using LibraryManagementApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository ??
                throw new ArgumentNullException(nameof(categoryRepository));
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] CategoryQueryParameters categoryQueryParameters)
        {
            var categories = 
                _categoryRepository
                .GetAll(categoryQueryParameters)
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name
                });

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categoryRepository
                .GetById(id);

            if (category == null) return NotFound();

            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };

            return Ok(categoryDto);
        }

        [HttpPost]
        public IActionResult Create(CategoryDto categoryDto)
        {
            var createdCategory = new Category
            {
                Id = categoryDto.Id,
                Name = categoryDto.Name
            };

            _categoryRepository.Create(createdCategory);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdCategory.Id },
                createdCategory);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, UpdateCategoryDto updateCategoryDto)
        {
            var category = _categoryRepository
                .GetById(id);

            if (category == null) return NotFound();

            category.Name = updateCategoryDto.Name;

            _categoryRepository.Update(category);

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public IActionResult Update(int id, JsonPatchDocument<UpdateCategoryDto> patch)
        {
            var category = _categoryRepository
                .GetById(id);

            if (category == null) return NotFound();

            var categoryToPatch = new UpdateCategoryDto()
            {
                Name = category.Name
            };

            patch.ApplyTo(categoryToPatch, ModelState);

            if (patch == null) return BadRequest();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (!TryValidateModel(categoryToPatch)) return BadRequest(ModelState);

            category.Name = categoryToPatch.Name;

            _categoryRepository.Update(category);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var category = _categoryRepository
                .GetById(id);

            if (category == null) return NotFound();

            _categoryRepository.Delete(id);

            return NoContent();
        }
    }
}
