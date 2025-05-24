using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.PayFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesRepository _roleRepository;
        public RolesController(IRolesRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        //Get all categories
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleRepository.GetAllRoles();
            return Ok(roles);
        }
    }
}
