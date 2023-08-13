using Microsoft.AspNetCore.Mvc;
using NominalBackend.Domain.Engineers.Models;
using NominalBackend.Domain.Items.Services;

namespace NominalBackend.Controllers
{
    [ApiController]
    [Route("EngineerPortfolioController")]
    public class EngineerPortfolioController : Controller
    {
        private IEngineerPortfolioService _engineerPortfolioService;
        private IEngineerService _engineerService;

        public EngineerPortfolioController(IEngineerPortfolioService engineerPortfolioService, IEngineerService engineerService)
        {
            _engineerPortfolioService = engineerPortfolioService;
            _engineerService = engineerService;
        }

        [HttpPost]
        [Route("AddImage")]
        public async Task<IActionResult> AddImage(IFormFile image, [FromQuery] int engId)
        {
            if (image == null || image.Length == 0) { return BadRequest("No file was uploaded."); }

            if (!await _engineerPortfolioService.IsAPhotoFile(image.FileName)) { return BadRequest("Not supported file type"); }

            var imageData = new byte[image.Length];
            using (var stream = image.OpenReadStream())
            {
                await stream.ReadAsync(imageData, 0, (int)image.Length);
            }

            var entity = new EngineerPortfolio
            {
                Data = imageData,
                ImageName = image.FileName,
                EngineerId = engId
            };

            var createdImage = await _engineerPortfolioService.AddAsync(entity);
            entity.Url = $"https://localhost:7206/Image/GetImageBytesConvertion/{entity.id}";
            entity = await _engineerPortfolioService.UpdateImageUrl(entity, entity.Url);

            return Ok(new
            {
                entity.id,
                entity.Url
            });
        }

        [HttpGet]
        [Route("GetAllImages/{engId}", Name = "GetaAllImage")]
        public async Task<IActionResult> GetAllImges()
        {

            await _engineerPortfolioService.GetAllAsync();
            return Ok(new
            {
                
            });
        }
    }
}
