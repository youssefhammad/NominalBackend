using Microsoft.AspNetCore.Mvc;
using NominalBackend.DataTransferObjects;
using NominalBackend.Domain.Categories.Services;
using NominalBackend.Domain.Images.Services;
using NominalBackend.Domain.Items.Models;
using NominalBackend.Domain.Items.Services;
using NominalBackend.Domain.SubCategories.Services;
using NominalBackend.Helpers.Enums;
using NominalBackend.Helpers.Filters;

namespace NominalBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly ICategoryService _categoryService;
        private readonly IImageService _imageService;
        private readonly IColorService _colorService;

        public ItemController(IItemService itemService, ISubCategoryService subCategoryService,
            ICategoryService categoryService, IImageService imageService, IColorService colorService)
        {
            _itemService = itemService;
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
            _imageService = imageService;
            _colorService = colorService;
        }

        [HttpGet]
        [Route("GetItem/{id}", Name = "GetItem")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _itemService.GetByIdAsync(id);
            if (item == null) { return NotFound(); }
            return Ok(new
            {
                item
            });
        }


        [HttpGet]
        [Route("GetAllItems", Name = "GetAllItems")]
        public async Task<IActionResult> GetAll()
        {
            var items = await _itemService.GetAllAsync();
            if (!items.Any()) { return NotFound(); }
            return Ok(new
            {
                items
            });
        }

        [HttpPost]
        [Route("CreateItem", Name = "CreateItem")]
        public async Task<IActionResult> Create(Item item)
        {
            if (item.CategoryId != default(int))
            {
                var category = await _categoryService.GetByIdAsync(item.CategoryId);
                if (category == null) { return BadRequest("Invalid CategoryId"); }
                var SubCatId = item.SubCategoryId.Value;
                if (SubCatId != default(int))
                {
                    var subCategory = await _subCategoryService.GetByIdAsync(SubCatId);
                    if (subCategory == null) { return BadRequest("Invalid SubCategoryId"); }
                    bool matchingSubAndCategory = await _subCategoryService.IsSubCategoryRelatesToCategoty(SubCatId, item.CategoryId);
                    if (!matchingSubAndCategory) { return BadRequest("SubCategory Not Match Category"); }
                }
            }
            item.State = State.NotPublished;
            await _itemService.AddAsync(item);
            return Ok(new
            {
                item.Id
            });
        }

        [HttpPut]
        [Route("UpdateItem", Name = "UpdateItem")]
        public async Task<IActionResult> Update(Item item)
        {
            await _itemService.UpdateAsync(item);
            return Ok(new
            {
                item
            });
        }

        [HttpDelete]
        [Route("DeleteItem", Name = "DeleteItem")]
        public async Task<IActionResult> Delete(Item item)
        {
            await _itemService.DeleteAsync(item);
            return Ok(new
            {
                item
            });
        }

        [HttpPost]
        [Route("FilterItems", Name = "FilterItems")]
        public async Task<IActionResult> FilterItems(ItemFilter filter, [FromQuery] int skip = 0, [FromQuery] int size = 9)
        {
            var items = await _itemService.FilterItems(filter);
            var filteredItemsTotalCount = await _itemService.CalculateTotalNumberOfFilteredItems(items);
            var paginateditems = await _itemService.PagenateItems(items, skip, size);
            if (!paginateditems.Any())
            {
                return NotFound("No Items Found");
            }
            var enabledNextButton = await _itemService.EnableNextButton(filteredItemsTotalCount, paginateditems.Count() + skip);

            List<GetAndFilterItemsDTO> itemsDTO = new List<GetAndFilterItemsDTO>();

            foreach (var paginateditem in paginateditems)
            {
                await _imageService.GetImagesByItemId(paginateditem.Id);
                var availableColorsForitem = await _colorService.GetColorsForItemsById(paginateditem.Id);

                var itemDTO = new GetAndFilterItemsDTO
                {
                    Item = paginateditem,
                    AvailableColors = availableColorsForitem.ToList()
                };

                itemsDTO.Add(itemDTO);
            }

            return Ok(new
            {
                itemsDTO,
                enabledNextButton
            });
        }

        [HttpGet]
        [Route("ChnageItemStateToBeActive/{itemId}", Name = "ChnageItemStateToBeActive")]
        public async Task<IActionResult> ChnageItemStateToBeActive(int itemId)
        {
            var item = await _itemService.GetByIdAsync(itemId);
            if (item == null) { return NotFound(); }
            
            item.State = State.Active;
            await _itemService.UpdateAsync(item);
            return Ok(new
            {
                item.Id
            });
        }


    }
}
