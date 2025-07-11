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

    // GET api/usuarios/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var usuario = await _usuarioService.ObtenerUsuarioPorIdAsync(id);

        if (usuario == null)
            return NotFound(new { message = "Usuario no encontrado." });

        return Ok(usuario);
    }

    // POST api/usuarios
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] UsuarioDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Nombre) || string.IsNullOrWhiteSpace(dto.Contrasena))
            return BadRequest(new { message = "Nombre y contraseña son obligatorios." });

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
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UsuarioDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Usuario) || string.IsNullOrWhiteSpace(dto.Contrasena))
            return BadRequest(new { message = "Usuario y contraseña son obligatorios." });

        var usuario = await _usuarioService.ValidarCredencialesAsync(dto.Usuario, dto.Contrasena);

        if (usuario == null)
            return Unauthorized(new { message = "Credenciales inválidas." });

        return Ok(new { message = "Login exitoso", usuario });
    }
    // PUT api/usuarios/{id}/cambiar-contraseña
    [HttpPut("{id}/cambiar-contraseña")]
    public async Task<IActionResult> CambiarContrasena(int id, [FromBody] UsuarioDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.NuevaContrasena))
            return BadRequest(new { message = "La contraseña no puede estar vacía." });

        dto.IdUsuario = id; // Aseguramos que el ID esté en el DTO
        var resultado = await _usuarioService.CambiarContrasenaAsync(dto);

        if (!resultado)
            return NotFound(new { message = "Usuario no encontrado." });

        return Ok(new { message = "Contraseña actualizada exitosamente." });
    }

    // GET: api/usuarios/Dni
    [HttpGet("Dni/{Dni}")]
    [Produces("application/json")]
    public async Task<IActionResult> Get(string Dni)
    {
        var usuarios = await _usuarioService.GetByDNIAsync(Dni);

        if (usuarios == null || !usuarios.Any())
            return NotFound(new { message = "Usuario no encontrado." });

        return Ok(usuarios);
    }
}
