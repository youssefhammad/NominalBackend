using Microsoft.AspNetCore.Mvc;
using NominalBackend.Domain.WebSiteStaticInfo.StaticData.Models;
using NominalBackend.Domain.WebSiteStaticInfo.StaticData.Services;

namespace NominalBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StaticDataController : Controller
    {
        private readonly IStaticDataService _staticDataService;

        public StaticDataController(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        [HttpGet]
        [Route("GetStaticDataById/{id}", Name = "GetStaticDataById")]
        public async Task<IActionResult> GetStaticDataById(int id)
        {
            var data = await _staticDataService.GetByIdAsync(id);
            if (data == null) { return NotFound(); }
            return Ok(new
            {
                data
            });
        }

        [HttpGet]
        [Route("GetAllData", Name = "GetAllData")]
        public async Task<IActionResult> GetAllData()
        {
            var data = await _staticDataService.GetAllAsync();
            if (!data.Any()) { return NotFound(); }
            var staticDataDictionary = data.Select(sd => new StaticData
            {
                Key = sd.Key,
                Value = sd.Value
            })
            .ToDictionary(dto => dto.Key, dto => dto.Value);
            return Ok(new
            {
                staticDataDictionary
            });
        }

        [HttpPost]
        [Route("CreateData", Name = "CreateData")]
        public async Task<IActionResult> CreateData(StaticData data)
        {
            var createdData = await _staticDataService.AddAsync(data);
            return Ok(new
            {
                createdData.Id
            });
        }

        [HttpDelete]
        [Route("DeleteData/{staticDataId}", Name = "DeleteData")]
        public async Task<IActionResult> DeleteData(int staticDataId)
        {
            var data = await _staticDataService.GetByIdAsync(staticDataId);
            if (data == null) { return NotFound(); }
            await _staticDataService.DeleteAsync(data);
            return Ok();
        }

        [HttpDelete]
        [Route("UpdateData", Name = "UpdateData")]
        public async Task<IActionResult> UpdateData(StaticData staticData)
        {
            var data = await _staticDataService.GetByIdAsync(staticData.Id);
            if (data == null) { return NotFound(); };
            await _staticDataService.UpdateAsync(data);
            return Ok(new
            {
                data.Id
            });

        }

    }
}
