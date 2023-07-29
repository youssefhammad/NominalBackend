using Microsoft.AspNetCore.Mvc;
using NominalBackend.Domain.Categories.Models;
using NominalBackend.Domain.Categories.Services;

namespace NominalBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        [Route("GetCategory/{id}", Name = "GetCategory")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if(category == null) { return NotFound(); }
            return Ok(new
            {
                category
            });
        }


        [HttpGet]
        [Route("GetAllCategories", Name = "GetAllCategories")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
            if(!categories.Any()) { return NotFound(); }
            return Ok(new
            {
                categories
            });
        }

        [HttpPost]
        [Route("CreateCategory", Name = "CreateCategory")]
        public async Task<IActionResult> Create(Category category)
        {
            await _categoryService.AddAsync(category);
            return Ok(new
            {
                category
            });
        }

        [HttpPut]
        [Route("UpdateCategory", Name = "UpdateCategory")]
        public async Task<IActionResult> Update(Category category)
        {
            await _categoryService.UpdateAsync(category);
            return Ok(new
            {
                category
            });
        }

        [HttpDelete]
        [Route("DeleteCategory", Name = "DeleteCategory")]
        public async Task<IActionResult> Delete(Category category)
        {
            await _categoryService.DeleteAsync(category);
            return Ok(new
            {
                category
            });
        }

    }
}
