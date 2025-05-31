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
        private readonly IHistorialValidacionesRepository _historialValidacionesRepository;

        public HistorialValidacionesController(IHistorialValidacionesRepository historialValidacionesRepository)
        {
            _historialValidacionesRepository = historialValidacionesRepository;
        }
        // Get all validation history records
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var historialValidaciones = _historialValidacionesRepository.GetAll();
            return Ok(historialValidaciones);
        }
        // Get a specific validation history record by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var historialValidacion = _historialValidacionesRepository.GetById(id);
            if (historialValidacion == null)
            {
                return NotFound();
            }
            return Ok(historialValidacion);
        }
        // Add a new validation history record
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] HistorialValidaciones historialValidacion)
        {
            if (historialValidacion == null)
            {
                return BadRequest("Invalid data.");
            }
            _historialValidacionesRepository.Add(historialValidacion);
            return CreatedAtAction(nameof(GetById), new { id = historialValidacion.IdHistorial }, historialValidacion);
        }
        // Update an existing validation history record
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HistorialValidaciones historialValidacion)
        {
            if (historialValidacion == null || historialValidacion.IdHistorial != id)
            {
                return BadRequest("Invalid data.");
            }
            var existingRecord = _historialValidacionesRepository.GetById(id);
            if (existingRecord == null)
            {
                return NotFound();
            }
            _historialValidacionesRepository.Update(historialValidacion);
            return NoContent();
        }
        // Delete a validation history record
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingRecord = _historialValidacionesRepository.GetById(id);
            if (existingRecord == null)
            {
                return NotFound();
            }
            _historialValidacionesRepository.Delete(id);
            return NoContent();
        }




    }
}
