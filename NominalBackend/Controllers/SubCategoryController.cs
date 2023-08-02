using Microsoft.AspNetCore.Mvc;
using NominalBackend.Domain.Categories.Services;
using NominalBackend.Domain.SubCategories.Models;
using NominalBackend.Domain.SubCategories.Services;
using NominalBackend.Helpers.Enums;

namespace NominalBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly ICategoryService _categoryService;

        public SubCategoryController(ISubCategoryService subCategoryService, ICategoryService categoryService)
        {
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("GetSubCategory/{id}", Name = "GetSubCategory")]
        public async Task<IActionResult> GetById(int id)
        {
            var subCategories = await _subCategoryService.GetByIdAsync(id);
            if (subCategories == null) { return NotFound(); }
            return Ok(new
            {
                subCategories
            });
        }


        [HttpGet]
        [Route("GetAllSubCategories", Name = "GetAllSubCategories")]
        public async Task<IActionResult> GetAll()
        {
            var subCategories = await _subCategoryService.GetAllAsync();
            if (!subCategories.Any()) { return NotFound(); }
            return Ok(new
            {
                subCategories
            });
        }

        [HttpPost]
        [Route("CreateSubCategory", Name = "CreateSubCategory")]
        public async Task<IActionResult> Create(SubCategory subCategory)
        {
            await _subCategoryService.AddAsync(subCategory);
            return Ok(new
            {
                subCategory
            });
        }

        [HttpPut]
        [Route("UpdateSubCategory", Name = "UpdateSubCategory")]
        public async Task<IActionResult> Update(SubCategory subCategory)
        {
            await _subCategoryService.UpdateAsync(subCategory);
            return Ok(new
            {
                subCategory
            });
        }

        [HttpDelete]
        [Route("DeleteSubCategory", Name = "DeleteSubCategory")]
        public async Task<IActionResult> Delete(SubCategory subCategory)
        {
            await _subCategoryService.DeleteAsync(subCategory);
            return Ok(new
            {
                subCategory
            });
        }

        [HttpPost]
        [Route("AttachNewSubCategoryToCategory", Name = "AttachNewSubCategoryToCategory")]
        public async Task<IActionResult> AddSubCategory(SubCategory subCategory)
        {
            var category = await _categoryService.GetByIdAsync(subCategory.CategoryId);
            if (category == null)
            {
                return BadRequest($"No category with {subCategory.CategoryId} Id");
            }
            subCategory.State = State.Active;
            await _subCategoryService.AddAsync(subCategory);
            return Ok(new
            {
                subCategory.Id
            });
            
        }
    }

}
