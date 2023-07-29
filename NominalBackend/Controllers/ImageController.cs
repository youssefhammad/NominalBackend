using Microsoft.AspNetCore.Mvc;
using NominalBackend.Domain.Images.Services;

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


    }
}
