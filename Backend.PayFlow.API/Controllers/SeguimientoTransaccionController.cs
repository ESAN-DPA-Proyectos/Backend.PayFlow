using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Backend.PayFlow.DOMAIN.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.PayFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeguimientoTransaccionController : ControllerBase
    {
        private readonly ISeguimientoTransaccionService _service;

        public SeguimientoTransaccionController(ISeguimientoTransaccionService service)
        {
            _service = service;
        }
        // Get all transaction tracking records
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.ObtenerTodosSeguimientoTransaccionesAsync();
            var result = items.Select(x => new SeguimientoTransaccionResponseDTO
            {
                idSeguimiento = x.IdSeguimiento,
                idTransaccion = x.IdTransaccion,
                hito = x.Hito,
                fechaHora = x.FechaHora,
                estado = x.Estado
            });
            return Ok(result);
        }
        // Get transaction tracking record by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.ObtenerSeguimientoTransaccionPorIdAsync(id);
            if (item == null)
                return NotFound();

            var dto = new SeguimientoTransaccionResponseDTO
            {
                idSeguimiento = item.IdSeguimiento,
                idTransaccion = item.IdTransaccion,
                hito = item.Hito,
                fechaHora = item.FechaHora,
                estado = item.Estado
            };
            return Ok(dto);
        }
        // Add a new transaction tracking record
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SeguimientoTransaccionCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new SeguimientoTransaccion
            {
                IdTransaccion = dto.idTransaccion,
                Hito = dto.hito,
                FechaHora = dto.fechaHora,
                Estado = dto.estado
            };

            var result = await _service.AgregarSeguimientoTransaccionAsync(entity);

            return CreatedAtAction(nameof(GetById), new { id = result.IdSeguimiento }, new SeguimientoTransaccionResponseDTO
            {
                idSeguimiento = result.IdSeguimiento,
                idTransaccion = result.IdTransaccion,
                hito = result.Hito,
                fechaHora = result.FechaHora,
                estado = result.Estado
            });
        }
        // Update an existing transaction tracking record
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SeguimientoTransaccionUpdateDTO dto)
        {
            if (id != dto.idSeguimiento)
                return BadRequest("ID mismatch");

            var entity = new SeguimientoTransaccion
            {
                IdSeguimiento = dto.idSeguimiento,
                IdTransaccion = dto.idTransaccion,
                Hito = dto.hito,
                FechaHora = dto.fechaHora,
                Estado = dto.estado
            };

            var updated = await _service.ActualizarSeguimientoTransaccionAsync(entity);
            if (updated == null)
                return NotFound();

            return NoContent();
        }
        // Delete a transaction tracking record
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.EliminarSeguimientoTransaccionAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
