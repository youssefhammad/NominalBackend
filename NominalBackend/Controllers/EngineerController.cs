using Microsoft.AspNetCore.Mvc;
using NominalBackend.Domain.Engineers.Models;
using NominalBackend.Domain.Items.Models;
using NominalBackend.Domain.Items.Services;

namespace NominalBackend.Controllers
{
    [ApiController]
    [Route("EngineerController")]
    public class EngineerController : Controller
    {
        private IEngineerService _engineerService;
        private IEngineerPortfolioService _engineerPortfolioService;

        public EngineerController(IEngineerService engineerService, IEngineerPortfolioService engineerPortfolioService)
        {
            _engineerService = engineerService;
            _engineerPortfolioService = engineerPortfolioService;
        }


        [HttpGet]
        [Route("GetEngineer/{id}", Name = "GetAllEngineer")]
        public async Task<IActionResult> GetById(int id)
        {
            var eng = await _engineerService.GetByIdAsync(id);
            return Ok(new
            {
                eng
            });
        }


        [HttpGet]
        [Route("GetAllEngineers",Name ="GetAllEngineers")]
        public async Task<IActionResult> GetAll()
        {
            var engs = await _engineerService.GetAllAsync();
            return Ok(new
            {
                engs
            });
        }

        [HttpPost]
        [Route("AddEngineer", Name = "AddEngineer")]
        public async Task<IActionResult> AddEngineer(Engineer engineer)
        {
            await _engineerService.AddAsync(engineer);
            return Ok(new
            {
                engineer.id
            });
        }

        [HttpDelete]
        [Route("DeleteEngineer/{id}", Name = "DeleteEngineer")]
        public async Task<IActionResult> DeleteEngineer(int id)
        {
            var EngineerExist = await _engineerService.GetByIdAsync(id);
            if (EngineerExist == null) 
            {
                return BadRequest();
            }
            await _engineerService.DeleteAsync(EngineerExist);
            return Ok();
        }
    }
}
