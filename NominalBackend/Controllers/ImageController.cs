using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NominalBackend.Domain.Images.Models;
using NominalBackend.Domain.Images.Services;
using NominalBackend.Helpers.Enums;
using System.IO;
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

            var entity = new Image
            {
                Data = imageData,
                ImageName = image.FileName,
                ItemId = itemId,
                State = State.Created,
                Size = image.Length
            };
            await _imageService.AddAsync(entity);
            return Ok(entity.Id);
        }

        [HttpGet]
        [Route("GetImage/{imageId}", Name = "GetImage")]
        public async Task<IActionResult> GetImagebyId(int imageId)
        {
            var image = await _imageService.GetByIdAsync(imageId);
            if (image == null) return NotFound();
            if (image.State == State.SoftDeleted) return BadRequest();
            if (!await _imageService.IsAPhotoFile(image.ImageName)) return BadRequest();
            return Ok(new
            {
                image
            });
        }

        [HttpGet]
        [Route("GetAllImages", Name = "GetAllImages")]
        public async Task<IActionResult> GetallImages(List<int> ImageIds)
        {
            List<Image> images = new();
            foreach (int Id in ImageIds)
            {
                Image? image = await _imageService.GetByIdAsync(Id);
                if (image == null) return NotFound();
                if (image.State == State.SoftDeleted) return BadRequest();
                if (!await _imageService.IsAPhotoFile(image.ImageName)) return BadRequest();
                images.Add(image);

            }
            return Ok(new
            {
                images
            });
        }

        [HttpDelete]
        [Route("DeleteImage/{imageId}", Name = "DeleteImage")]
        public async Task<IActionResult> DeleteImage(int imageId)
        {
            Image? image = await _imageService.GetByIdAsync(imageId);
            var isValidImage = image != null && image.State != State.SoftDeleted
                && image.Size > 0 && await _imageService.IsAPhotoFile(image.ImageName);
            if (!isValidImage) return BadRequest();

            image.State = State.SoftDeleted;
            image.UpdatedAt = DateTime.Now;
            await _imageService.UpdateAsync(image);
            return Ok(new
            {
                image
            });
        }
    }
}
