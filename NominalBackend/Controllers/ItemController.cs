using Microsoft.AspNetCore.Mvc;
using NominalBackend.Domain.Items.Models;
using NominalBackend.Domain.Items.Services;
using NominalBackend.Helpers.Filters;

namespace NominalBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        [Route("GetItem/{id}", Name = "GetItem")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _itemService.GetByIdAsync(id);
            if(item == null) { return NotFound(); }            
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
            await _itemService.AddAsync(item);
            return Ok(new
            {
                item
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
        public async Task<IActionResult> FilterItems(ItemFilter filter)
        {
            var items = await _itemService.FilterItems(filter);
            return Ok(new { items });
        }
    }
}
