using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.PayFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // POST api/usuarios
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioRegisterDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre) || string.IsNullOrWhiteSpace(dto.Contrasena))
                return BadRequest("Nombre y contraseña son obligatorios.");

            var resultado = await _usuarioService.RegistrarUsuarioAsync(dto);

            if (resultado)
                return Ok(new { message = "Usuario registrado exitosamente." });

            return StatusCode(500, new { message = "Error al registrar usuario." });
        }

        // (Puedes dejar los otros métodos vacíos o eliminarlos si no los usas)
    }
}
