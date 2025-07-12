using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.PayFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioRolesController : ControllerBase
    {
        private readonly IUsuarioRolService _svc;

        public UsuarioRolesController(IUsuarioRolService svc)
        {
            _svc = svc;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioRolDto dto)
        {
            var ok = await _svc.AsignarRolAsync(dto);
            if (ok) return Ok(new { message = "Rol asignado correctamente" });
            return StatusCode(500, new { message = "No se pudo asignar el rol" });
        }
    }
}