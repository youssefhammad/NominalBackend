using Microsoft.AspNetCore.Mvc;
using NominalBackend.Domain.Images.Models;
using NominalBackend.Domain.Images.Services;

namespace NominalBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColorController : Controller
    {
        private readonly IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet]
        [Route("GetColorIyId/{id}", Name = "GetColorById")]
        public async Task<IActionResult> GetById(int id)
        {
            var color = await _colorService.GetByIdAsync(id);
            if (color == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                color
            });
        }

        [HttpGet]
        [Route("GetColors", Name ="GetColors")]
        public async Task<IActionResult> GetAll()
        {
            var colors = await _colorService.GetAllAsync();
            if(!colors.Any())
            {
                return NotFound();
            }
            return Ok(new
            {
                colors
            });
        }


        [HttpPost]
        [Route("AddColor" , Name = "AddColor")]
        public async Task<IActionResult> Create(Color color) 
        {
            await _colorService.AddAsync(color);
            return Ok();

        }

        [HttpDelete]
        [Route("DeleteColor", Name ="DeleteColor")]
        public async Task<IActionResult> Delete(Color color)
        {
            var colorExsist = await _colorService.GetByIdAsync(color.Id);
            if (colorExsist == null)
            {
                return BadRequest();
            }
            await _colorService.DeleteAsync(color);
            return Ok();
        }


        [HttpPut]
        [Route("UpdateColor",Name = "UpdateColor")]
        public async Task<IActionResult> Update(Color color)
        {
            //var colorExcist = await _colorService.GetByIdAsync(color.id);
            //if (colorExcist == null)
            //{
            //    return BadRequest();
            //}
            await _colorService.UpdateAsync(color);
            return Ok(color);
        }
    }
}
