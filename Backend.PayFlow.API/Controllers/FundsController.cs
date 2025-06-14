using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.PayFlow.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FundsController : ControllerBase
    {
        private readonly IFondosRepository _fondosRepository;
        public FundsController(IFondosRepository fondosRepository)
        {
            _fondosRepository = fondosRepository;
        }
        // GET: all fondos
        [HttpGet]
        public async Task<IActionResult> GetAllFunds()
        {
            var fondos = await _fondosRepository.GetAllFunds();
            return Ok(fondos);
        }
        // GET: fondos by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFondosById(int id)
        {
            var fondos = await _fondosRepository.GetFondosById(id);
            if (fondos == null)
            {
                return NotFound();
            }
            return Ok(fondos);
        }
        // POST: Add fondo - api/v1/funds
        [HttpPost]
        public async Task<IActionResult> AddFondos([FromBody] Fondos fondos)
        {
            if (fondos == null)
            {
                return BadRequest("Fondo data is required.");
            }
            var fondosId = await _fondosRepository.AddFondos(fondos);
            return CreatedAtAction(nameof(GetFondosById), new { id = fondosId }, fondos);
        }
        // PUT: Update fondo - api/v1/funds/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFondos(int id, [FromBody] Fondos fondos)
        {
            if (id != fondos.IdFondo)
            {
                return BadRequest("Invalid data.");
            }
            var result = await _fondosRepository.UpdateFondos(fondos);
            if (!result)
            {
                return NotFound("Fondo not found.");
            }
            return NoContent();
        }
                
        // DELETE: api/v1/funds/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFondos(int id)
        {
            var result = await _fondosRepository.DeleteFondos(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
