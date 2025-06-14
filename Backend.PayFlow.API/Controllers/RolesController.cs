using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Backend.PayFlow.DOMAIN.Core.Services;
using Backend.PayFlow.DOMAIN.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.PayFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;

        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }


        // GET: api/Roles
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var roles = await _rolesService.ListarRoles();
            return Ok(roles);
        }

        // GET: api/Roles/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var rol = await _rolesService.BuscarRolPorId(id);

            if (rol == null)
                return NotFound(new { message = "Rol no encontrado." });

            return Ok(rol);
        }

        // POST: api/Roles
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RolesCreateDTO dto)
        {
            var resultado = await _rolesService.RegistrarRol(dto);

            if (resultado)
                return Ok(new 
                    {
                        resultado,
                        message = "Rol registrado exitosamente.",
                        dto
                    }
                );

            return StatusCode(500, new { message = "Error al registrar el rol." });
        }

        // PUT: api/Roles
        [HttpPut]
        public async Task<IActionResult> UpdateRoles(Roles rol)
        {
            var resultado = await _rolesService.ActualizarRol(rol);

            if (resultado)
                return Ok(new
                    {
                        resultado,
                        message = "Rol actualizado exitosamente.",
                        rol
                    }
                );

            return StatusCode(500, new { message = "Error al actualizar el rol." });

        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoles(int id)
        {
            var resultado = await _rolesService.RemoveRol(id);

            if (resultado)
                return Ok(new
                    {
                        resultado,
                        message = "Rol eleminado exitosamente.",
                        id
                    }
                );

            return StatusCode(500, new { message = "Error al eliminar el rol." });

        }

    }
}
