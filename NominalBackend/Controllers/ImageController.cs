using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NominalBackend.Domain.Images.Models;
using NominalBackend.Domain.Images.Services;
using NominalBackend.Domain.Items.Services;
using NominalBackend.Helpers.Enums;

namespace NominalBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;
        private readonly IItemService _itemService;
        private readonly IColorService _colorService;

        public ImageController(IImageService imageService, IItemService itemService, IColorService colorService)
        {
            _imageService = imageService;
            _itemService = itemService;
            _colorService = colorService;
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
                State = State.Active,
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

        [HttpPost]
        [Route("AddMultipleImages", Name = "AddMultipleImages")]
        public async Task<IActionResult> AddMultipleImages(List<IFormFile> images, [FromQuery] List<int> colorIds, [FromQuery] int itemId)
        {
            var item = await _itemService.GetByIdAsync(itemId);
            if (item == null)
            {
                return BadRequest("Item Not Found");
            }
            if (colorIds.Count != images.Count)
            {
                return BadRequest("You Must Attach Color To Each Image Ttem");
            }
            List<Image> newImages = new List<Image>();
            for (int i = 0; i < images.Count; i++)
            {
                var colorId = colorIds[i]; // Get the colorId at the corresponding index

                var color = await _colorService.GetByIdAsync(colorId);
                if (color == null)
                {
                    return BadRequest($"Color with id {colorId} Not Found");
                }

                if (!await _imageService.IsAPhotoFile(images[i].FileName)) { return BadRequest("Not supported file type"); }
                var imageData = new byte[images[i].Length];
                using (var stream = images[i].OpenReadStream())
                {
                    await stream.ReadAsync(imageData, 0, (int)images[i].Length);
                }

                var entity = new Image
                {
                    Data = imageData,
                    ImageName = images[i].FileName,
                    ItemId = itemId,
                    State = State.Active,
                    Size = images[i].Length,
                    ColorId = colorIds[i]
                };
                newImages.Add(entity);
            }

            await _imageService.AddMultipleAsync(newImages);
            List<int> newImagesIds = newImages.Select(image => image.Id).ToList();
            return Ok(new
            {
                newImagesIds
            });
        }

        [HttpGet]
        [Route("GettAllImagesForItem/{itemId}", Name = "GettAllImagesForItem")]
        public async Task<IActionResult> GettAllImagesForItem(int itemId)
        {
            var item = await _itemService.GetByIdAsync(itemId);
            if(item == null) { return BadRequest($"No Item With ID {itemId}"); }

            var images = await _imageService.GetImagesByItemId(itemId);
            return Ok(new
            {
                images
            });
        }

        [HttpPost]
        [Route("UpdateItemMainImages", Name = "UpdateItemMainImages")]
        public async Task<IActionResult> UpdateItemMainImages(List<Image> images)
        {
            if (!await _imageService.ValidateIsDefaultItemImage(images))
                return BadRequest("For each item, there should be only one main image for displaying.");

            if (!await _imageService.ValidateIsDefaultItemColor(images))
                return BadRequest("For each group of the same color, there should be only one main image for displaying.");

            await _imageService.UpdateMultipleAsync(images);
            return Ok();
        }
    }

}
