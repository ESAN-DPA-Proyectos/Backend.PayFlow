using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.PayFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialValidacionesController : ControllerBase
    {
        private readonly IHistorialValidacionesService _service;
        public HistorialValidacionesController(IHistorialValidacionesService service)
        {
            _service = service;
        }
        // Get all validations
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _service.GetAllValidationsAsync();
            var result = entities.Select(e => new HistorialValidacionesResponseDTO
            {
                IdHistorial = e.IdHistorial,
                TipoValidacion = e.TipoValidacion,
                Resultado = e.Resultado,
                Observacion = e.Observacion,
                FechaValidacion = e.FechaValidacion,
                ValidadoPor = e.ValidadoPor
            }).ToList();

            return Ok(result);
        }
        // Get validation by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _service.GetValidationByIdAsync(id);
            if (entity == null)
                return NotFound();

            var dto = new HistorialValidacionesResponseDTO
            {
                IdHistorial = entity.IdHistorial,
                TipoValidacion = entity.TipoValidacion,
                Resultado = entity.Resultado,
                Observacion = entity.Observacion,
                FechaValidacion = entity.FechaValidacion,
                ValidadoPor = entity.ValidadoPor
            };

            return Ok(dto);
        }
        // Add a new validation
        [HttpPost]
        public IActionResult Add([FromBody] HistorialValidacionesCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = new HistorialValidaciones
            {
                IdTransaccion = dto.IdTransaccion,
                TipoValidacion = dto.TipoValidacion,
                Resultado = dto.Resultado,
                Observacion = dto.Observacion,
                ValidadoPor = dto.ValidadoPor,
                FechaValidacion = DateTime.Now
            };

            _service.AddValidation(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.IdHistorial }, dto);
        }
        // Update an existing validation
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HistorialValidacionesUpdateDTO dto)
        {
            var existing = await _service.GetValidationByIdAsync(id);
            if (existing == null)
                return NotFound();

            // Solo actualiza los campos permitidos
            existing.Resultado = dto.Resultado;
            existing.Observacion = dto.Observacion;
            existing.FechaValidacion = dto.FechaValidacion ?? DateTime.Now;

            _service.UpdateValidation(existing);
            return NoContent();
        }
        // Delete a validation
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _service.GetValidationByIdAsync(id);
            if (existing == null)
                return NotFound();

            _service.DeleteValidation(id);
            return NoContent();
        }
    }
}
