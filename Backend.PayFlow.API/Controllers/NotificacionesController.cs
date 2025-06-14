using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class NotificacionesController : ControllerBase
{
    private readonly NotificacionService _service;

    public NotificacionesController(NotificacionService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateNotificationDTO dto)
    {
        await _service.CreateAsync(dto);
        return Ok(new { message = "Notificación creada correctamente" });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()

    {
        var notificaciones = await _service.GetAllAsync();
        return Ok(notificaciones);
    }
}
