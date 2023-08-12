using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace NominalBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatisticsController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public StatisticsController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("ClientUserCount")]
        public async Task<IActionResult> GetClientUserCount()
        {
            var role = await _roleManager.FindByNameAsync("Client");
            if (role == null)
            {
                return NotFound(new { Message = "Role not found" });
            }
            var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name);
            var numberOfUsers = usersInRole.Count;

            return Ok(new { NumberOfUsers = numberOfUsers });
        }
    }
}
