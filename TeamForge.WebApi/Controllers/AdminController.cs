using Microsoft.AspNetCore.Mvc;
using TeamForge.Model;
using TeamForge.Service.Common;

namespace TeamForge.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpGet("{adminId}")]
        public IActionResult GetAdmin(Guid adminId)
        {
            var admin = adminService.GetAdminById(adminId);
            if (admin == null)
            {
                return NotFound(); // Admin not found
            }
            return Ok(admin);
        }

        [HttpGet]
        public IActionResult GetAllAdmins()
        {
            var admins = adminService.GetAllAdmins();
            return Ok(admins);
        }

        [HttpPost]
        public IActionResult AddAdmin([FromBody] Admin admin)
        {
            if (admin == null)
            {
                return BadRequest("Admin is null.");
            }

            adminService.AddAdmin(admin);
            return CreatedAtAction(nameof(GetAdmin), new { adminId = admin.Id }, admin);
        }

        [HttpPut("{adminId}")]
        public IActionResult UpdateAdmin(Guid adminId, [FromBody] Admin admin)
        {
            if (admin == null || adminId != admin.Id)
            {
                return BadRequest("Admin ID mismatch.");
            }

            var existingAdmin = adminService.GetAdminById(adminId);
            if (existingAdmin == null)
            {
                return NotFound("Admin not found.");
            }

            adminService.UpdateAdmin(admin);
            return NoContent();
        }

        [HttpDelete("{adminId}")]
        public IActionResult DeleteAdmin(Guid adminId)
        {
            var admin = adminService.GetAdminById(adminId);
            if (admin == null)
            {
                return NotFound("Admin not found.");
            }

            adminService.DeleteAdmin(adminId);
            return NoContent();
        }
    }
}
