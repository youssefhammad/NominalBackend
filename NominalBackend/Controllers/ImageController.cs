using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NominalBackend.Domain.Images.Models;
using NominalBackend.Domain.Images.Services;
using NominalBackend.Helpers.Enums;
using System.Xml;

namespace NominalBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        [Route("AddImage", Name = "AddImage")]
        public async Task<IActionResult> AddImage(IFormFile image, int itemId)
        {
            if (image == null || image.Length == 0) { return BadRequest("No file was uploaded."); }

            if (!await _imageService.IsAPhotoFile(image.FileName)) { return BadRequest("Not supported file type"); }

            var imageData = new byte[image.Length];
            using (var stream = image.OpenReadStream())
            {
                await stream.ReadAsync(imageData, 0, (int)image.Length);
            }

            var entity = new Image {
                Data = imageData ,
                ImageName = image.FileName,
                ItemId = itemId,
                State = State.Created
            };
            await _imageService.AddAsync(entity);
            return Ok(entity.Id);
        }


    }
}
