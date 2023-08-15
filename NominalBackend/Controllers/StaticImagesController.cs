using Microsoft.AspNetCore.Mvc;
using NominalBackend.Domain.Categories.Services;
using NominalBackend.Domain.Items.Models;
using NominalBackend.Domain.Items.Services;
using NominalBackend.Domain.SubCategories.Services;
using NominalBackend.Domain.WebSiteStaticInfo.StaticImages.Models;
using NominalBackend.Domain.WebSiteStaticInfo.StaticImages.Services;
using NominalBackend.Helpers.Enums;

namespace NominalBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StaticImagesController : Controller
    {
        private readonly IStaticImageService _staticImageService;
        private readonly IEngineerService _engineerService;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;

        public StaticImagesController(IStaticImageService staticImageService, IEngineerService engineerService,
            ICategoryService categoryService, ISubCategoryService subCategoryService)
        {
            _staticImageService = staticImageService;
            _engineerService = engineerService;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
        }


        [HttpGet("GetImageBytesConvertion/{id}")]
        public async Task<IActionResult> GetImageBytes(int id)
        {
            var image = await _staticImageService.GetByIdAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            string fileName = image.ImageName;
            string extension = System.IO.Path.GetExtension(fileName).ToLower();

            Dictionary<string, string> mediaTypes = new Dictionary<string, string>()
                    {
                        { ".jpg", "image/jpeg" },
                        { ".jpeg", "image/jpeg" },
                        { ".png", "image/png" },
                        { ".gif", "image/gif" },
                    };

            if (!mediaTypes.TryGetValue(extension, out string contentType))
            {
                return BadRequest("Unsupported file type");
            }

            return File(image.Data, contentType);
        }

        [HttpGet]
        [Route("GetStaticImageById/{id}", Name = "GetStaticImageById")]
        public async Task<IActionResult> GetStaticImageById(int id)
        {
            var image = await _staticImageService.GetByIdAsync(id);
            if (image == null) { return NotFound(); }
            return Ok(new
            {
                image.Id,
                image.Type,
                image.URL
            });
        }

        [HttpGet]
        [Route("GetAllStaticImages", Name = "GetAllStaticImages")]
        public async Task<IActionResult> GetAllStaticImages()
        {
            var images = await _staticImageService.GetAllAsync();
            if (!images.Any()) { return NotFound(); }
            return Ok(new
            {
                images
            });
        }

        [HttpGet]
        [Route("GetEngImageProfilePhoto/{engId}", Name = "GetEngImageProfilePhoto")]
        public async Task<IActionResult> GetEngImageProfilePhoto(int engId)
        {
            var type = StaticImageType.EngineerProfile;
            var engProfileImage = await _staticImageService.GetStaticImageforTypeByRefrenceId(type, engId);

            return Ok(new
            {
                engProfileImage.Id,
                engProfileImage.URL
            });
        }

        [HttpGet]
        [Route("GetCoverImage", Name = "GetCoverImage")]
        public async Task<IActionResult> GetCoverImage()
        {
            var type = StaticImageType.CoverPhoto;
            var coverImage = await _staticImageService.GetStaticImageforTypeByRefrenceId(type);
            if(coverImage == null) { return NotFound(); }
            return Ok(new
            {
                coverImage.Id,
                coverImage.URL
            });
        }

        [HttpGet]
        [Route("GetCategoriesImages/{categoryId}", Name = "GetCategoriesImages")]
        public async Task<IActionResult> GetCategoriesImages(int categoryId)
        {
            var type = StaticImageType.Category;
            var categoryImages = await _staticImageService.GetMultipleStaticImageforTypeByRefrenceId(type, categoryId);
            if (!categoryImages.Any()) { return NotFound(); }
            List<string> categoryImagesUrls = new List<string>();
            foreach(var image in categoryImages)
            {
                categoryImagesUrls.Add(image.URL);
            }
            return Ok(new
            {
                categoryImagesUrls
            });
        }

        [HttpGet]
        [Route("GetSubCategoriesImages/{subCategoryId}", Name = "GetSubCategoriesImages")]
        public async Task<IActionResult> GetSubCategoriesImages(int subCategoryId)
        {
            var type = StaticImageType.SubCategory;
            var categoryImages = await _staticImageService.GetMultipleStaticImageforTypeByRefrenceId(type, subCategoryId);
            if (!categoryImages.Any()) { return NotFound(); }
            List<string> subCategoryImagesUrls = new List<string>();
            foreach (var image in categoryImages)
            {
                subCategoryImagesUrls.Add(image.URL);
            }
            return Ok(new
            {
                subCategoryImagesUrls
            });
        }

        [HttpPost]
        [Route("CreateEngImageProfilePhoto/{engId}", Name = "CreateEngImageProfilePhoto")]
        public async Task<IActionResult> CreateEngImageProfilePhoto(IFormFile image, int engId)
        {
            var engineer = await _engineerService.GetByIdAsync(engId);
            if (engineer == null) { return NotFound(); }

            //IF ENG HAS IMAGE DELETE THE EXISTING ONE THEN ADD NEW PROFILE IMAGE TO HIM
            var engImage = await _staticImageService.GetStaticImageforTypeByRefrenceId(StaticImageType.EngineerProfile, engId);
            if (engImage != null)
            {
                await _staticImageService.DeleteAsync(engImage);
            }

            if (image == null || image.Length == 0) { return BadRequest("No file was uploaded."); }

            if (!await _staticImageService.IsAPhotoFile(image.FileName)) { return BadRequest("Not supported file type"); }

            var imageData = new byte[image.Length];
            using (var stream = image.OpenReadStream())
            {
                await stream.ReadAsync(imageData, 0, (int)image.Length);
            }

            StaticImage staticImage = new StaticImage()
            {
                Data = imageData,
                Type = StaticImageType.EngineerProfile,
                ReferenceId = engId,
                ImageName = image.FileName
            };
            var createdStaticImage = await _staticImageService.AddAsync(staticImage);
            createdStaticImage.URL = $"https://localhost:7206/StaticImages/GetImageBytesConvertion/{createdStaticImage.Id}";
            var updatedImageObjectURL = await _staticImageService.UpdateAsync(createdStaticImage);
            return Ok(new
            {
                updatedImageObjectURL.Id,
                updatedImageObjectURL.URL
            });
        }

        [HttpPost]
        [Route("CreateCategoryImage", Name = "CreateCategoryImage")]
        public async Task<IActionResult> CreateCategoryImage(IFormFile image,[FromQuery] int categoryId, [FromQuery] string? description)
        {
            var category = await _categoryService.GetByIdAsync(categoryId);
            if (category == null) { return NotFound(); }


            if (image == null || image.Length == 0) { return BadRequest("No file was uploaded."); }

            if (!await _staticImageService.IsAPhotoFile(image.FileName)) { return BadRequest("Not supported file type"); }

            var imageData = new byte[image.Length];
            using (var stream = image.OpenReadStream())
            {
                await stream.ReadAsync(imageData, 0, (int)image.Length);
            }

            StaticImage staticImage = new StaticImage()
            {
                Data = imageData,
                Type = StaticImageType.Category,
                ReferenceId = categoryId,
                Description = description,
                ImageName = image.FileName
            };
            var createdStaticImage = await _staticImageService.AddAsync(staticImage);
            createdStaticImage.URL = $"https://localhost:7206/StaticImages/GetImageBytesConvertion/{createdStaticImage.Id}";
            var updatedImageObjectURL = await _staticImageService.UpdateAsync(createdStaticImage);
            return Ok(new
            {
                updatedImageObjectURL.Id,
                updatedImageObjectURL.URL
            });
        }

        [HttpPost]
        [Route("CreateSubCategoryImage", Name = "CreateSubCategoryImage")]
        public async Task<IActionResult> CreateSubCategoryImage(IFormFile image, [FromQuery] int subCategoryId, [FromQuery] string? description)
        {
            var category = await _subCategoryService.GetByIdAsync(subCategoryId);
            if (category == null) { return NotFound(); }


            if (image == null || image.Length == 0) { return BadRequest("No file was uploaded."); }

            if (!await _staticImageService.IsAPhotoFile(image.FileName)) { return BadRequest("Not supported file type"); }

            var imageData = new byte[image.Length];
            using (var stream = image.OpenReadStream())
            {
                await stream.ReadAsync(imageData, 0, (int)image.Length);
            }

            StaticImage staticImage = new StaticImage()
            {
                Data = imageData,
                Type = StaticImageType.SubCategory,
                ReferenceId = subCategoryId,
                Description = description,
                ImageName = image.FileName
            };
            var createdStaticImage = await _staticImageService.AddAsync(staticImage);
            createdStaticImage.URL = $"https://localhost:7206/StaticImages/GetImageBytesConvertion/{createdStaticImage.Id}";
            var updatedImageObjectURL = await _staticImageService.UpdateAsync(createdStaticImage);
            return Ok(new
            {
                updatedImageObjectURL.Id,
                updatedImageObjectURL.URL
            });
        }

        [HttpPost]
        [Route("CreateCoverImage", Name = "CreateCoverImage")]
        public async Task<IActionResult> CreateCoverImage(IFormFile image, [FromQuery] string? description)
        {
            //IF COVER IMAGE EXSITS DELETE THE EXISTING ONE THEN ADD NEW COVER IMAGE 
            var coverImage = await _staticImageService.GetStaticImageforTypeByRefrenceId(StaticImageType.CoverPhoto);
            if (coverImage != null)
            {
                await _staticImageService.DeleteAsync(coverImage);
            }

            if (image == null || image.Length == 0) { return BadRequest("No file was uploaded."); }

            if (!await _staticImageService.IsAPhotoFile(image.FileName)) { return BadRequest("Not supported file type"); }

            var imageData = new byte[image.Length];
            using (var stream = image.OpenReadStream())
            {
                await stream.ReadAsync(imageData, 0, (int)image.Length);
            }

            StaticImage staticImage = new StaticImage()
            {
                Data = imageData,
                Type = StaticImageType.CoverPhoto,
                Description = description,
                ImageName = image.FileName
            };
            var createdStaticImage = await _staticImageService.AddAsync(staticImage);
            createdStaticImage.URL = $"https://localhost:7206/StaticImages/GetImageBytesConvertion/{createdStaticImage.Id}";
            var updatedImageObjectURL = await _staticImageService.UpdateAsync(createdStaticImage);
            return Ok(new
            {
                updatedImageObjectURL.Id,
                updatedImageObjectURL.URL
            });
        }

        [HttpDelete]
        [Route("DeleteStaticImage/{id}", Name = "DeleteStaticImage")]
        public async Task<IActionResult> DeleteStaticImage(int id)
        {
            var staticImage = await _staticImageService.GetByIdAsync(id);
            if (staticImage == null) { return NotFound(); }
            await _staticImageService.DeleteAsync(staticImage);
            return Ok(new
            {
                staticImage.Id
            });
        }

    }
}
