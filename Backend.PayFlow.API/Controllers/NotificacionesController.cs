using Backend.PayFlow.DOMAIN.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class NotificacionesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateNotificationDTO dto)
    {
        // lógica de creación...
        return Ok(new { message = "Notificación creada correctamente" });
    }
}
