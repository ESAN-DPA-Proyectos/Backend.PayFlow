using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuariosController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var usuario = await _usuarioService.ObtenerUsuarioPorIdAsync(id);

        if (usuario == null)
            return NotFound(new { message = "Usuario no encontrado." });

        return Ok(usuario);
    }

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

    // GET api/usuarios
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var usuarios = await _usuarioService.ObtenerTodosLosUsuariosAsync();
        return Ok(usuarios);
    }


}
