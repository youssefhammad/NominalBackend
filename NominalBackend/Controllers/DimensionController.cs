using Microsoft.AspNetCore.Mvc;
using NominalBackend.Domain.Items.Models;
using NominalBackend.Domain.Items.Services;
using NominalBackend.Domain.Wishlists.Models;

namespace NominalBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DimensionController : Controller
    {
        private readonly IDimensionService _dimensionService;

        public DimensionController(IDimensionService dimensionService)
        {
            _dimensionService = dimensionService;
        }

        [HttpGet]
        [Route("GetDimension/{id}", Name = "GetDimension")]
        public async Task<IActionResult> GetById(int id)
        {
            var dimension = await _dimensionService.GetByIdAsync(id);
            if (dimension == null) { return NotFound(); }
            return Ok(new
            {
                dimension
            });
        }


        [HttpGet]
        [Route("GetAllDimensions", Name = "GetAllDimensions")]
        public async Task<IActionResult> GetAll()
        {
            var dimensions = await _dimensionService.GetAllAsync();
            if (!dimensions.Any()) { return NotFound(); }
            return Ok(new
            {
                dimensions
            });
        }

        [HttpPost]
        [Route("CreateDimension", Name = "CreateDimension")]
        public async Task<IActionResult> Create(Dimensions dimension)
        {
            await _dimensionService.AddAsync(dimension);
            return Ok(new
            {
                dimension
            });
        }

        [HttpPut]
        [Route("UpdateDimension", Name = "UpdateDimension")]
        public async Task<IActionResult> Update(Dimensions dimension)
        {
            await _dimensionService.UpdateAsync(dimension);
            return Ok(new
            {
                dimension
            });
        }

        [HttpDelete]
        [Route("DeleteDimension", Name = "DeleteDimension")]
        public async Task<IActionResult> Delete(Dimensions dimension)
        {
            await _dimensionService.DeleteAsync(dimension);
            return Ok(new
            {
                dimension
            });
        }
    }
}
