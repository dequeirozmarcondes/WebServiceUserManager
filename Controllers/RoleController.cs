using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebServiceUserManager.Dtos;
using WebServiceUserManager.Models;

namespace WebServiceUserManager.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleController(RoleManager<IdentityRole<Guid>> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        // Cria uma nova role
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleDto roleDto)
        {
            if (roleDto == null || string.IsNullOrEmpty(roleDto.RoleName))
                return BadRequest("Role name cannot be empty");

            var roleExist = await _roleManager.RoleExistsAsync(roleDto.RoleName);
            if (!roleExist)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole<Guid>(roleDto.RoleName));
                if (result.Succeeded)
                    return Ok(new { message = "Role created successfully" });
                else
                    return BadRequest(result.Errors);
            }

            return BadRequest("Role already exists");
        }

        // Adiciona uma role a um usuário
        [HttpPost("{userId}/roles")]
        public async Task<IActionResult> AddUserToRole(Guid userId, [FromBody] RoleDto roleDto)
        {
            if (roleDto == null || string.IsNullOrEmpty(roleDto.RoleName))
                return BadRequest(new { message = "Role name cannot be empty" });

            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return NotFound(new { message = "User not found" });

            var roleExist = await _roleManager.RoleExistsAsync(roleDto.RoleName);
            if (!roleExist)
                return BadRequest(new { message = "Role does not exist" });

            var result = await _userManager.AddToRoleAsync(user, roleDto.RoleName);
            if (result.Succeeded)
                return Ok(new { message = "User added to role successfully" });

            return BadRequest(result.Errors);
        }

        // Adiciona uma claim a um usuário
        [HttpPost("{userId}/claims")]
        public async Task<IActionResult> AddClaimToUser(Guid userId, [FromBody] ClaimDto claimDto)
        {
            if (claimDto == null || string.IsNullOrEmpty(claimDto.Type) || string.IsNullOrEmpty(claimDto.Value))
                return BadRequest(new { message = "Claim type and value cannot be empty" });

            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return NotFound(new { message = "User not found" });

            var claim = new System.Security.Claims.Claim(claimDto.Type, claimDto.Value);
            var result = await _userManager.AddClaimAsync(user, claim);
            if (result.Succeeded)
                return Ok(new { message = "Claim added to user successfully" });

            return BadRequest(result.Errors);
        }
    }
}