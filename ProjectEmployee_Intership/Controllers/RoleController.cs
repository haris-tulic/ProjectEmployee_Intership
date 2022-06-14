using Microsoft.AspNetCore.Mvc;
using ProjectEmployee_Intership.Core.Models.Dto;
using ProjectEmployee_Intership.Core.Models.Request;
using ProjectEmployee_Intership.Service.Interfaces;

namespace ProjectEmployee_IntershipAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;
        public RoleController(IRoleService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<RoleDto>>> GetAllRoles()
        {
            var response = await _service.GetRole();
            if (response == null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<RoleDto>> GetRoleById(int id)
        {
            var response = await _service.GetById(id);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<RoleDto>> AddNewRole(AddRoleRequest newRole)
        {
            var response = await _service.AddNewRole(newRole);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
