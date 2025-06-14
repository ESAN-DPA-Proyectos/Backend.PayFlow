using Backend.PayFlow.DOMAIN.Core.DTOs;
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
        //private readonly IFondosRepository _fondosRepository;
        //public FundsController(IFondosRepository fondosRepository)
        //{
        //    _fondosRepository = fondosRepository;
        //}
        private readonly IFondosService _fondosService;

        public FundsController(IFondosService fondosService)
        {
            _fondosService = fondosService;
        }
        // GET: all fondos
        [HttpGet]
        public async Task<IActionResult> GetAllFunds()
        {
            var fondos = await _fondosService.GetAllfunds();
            return Ok(fondos);
        }
        // GET: fondos by id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFondosById(int id)
        {
            var fondos = await _fondosService.GetFondosById(id);
            if (fondos == null)
            {
                return NotFound();
            }
            return Ok(fondos);
        }
        // POST: Add fondo - api/v1/funds
        [HttpPost]
        public async Task<IActionResult> AddFondos([FromBody] FondosCreateDTO fondosCreateDTO)
        {
            if (fondosCreateDTO == null)
            {
                return BadRequest("Fondo data is required.");
            }
            var fondosId = await _fondosService.AddFondos(fondosCreateDTO);
            return CreatedAtAction(nameof(GetFondosById), new { id = fondosId }, fondosCreateDTO);
        }
        // PUT: Update fondo - api/v1/funds/{id}
        
       
                
        // DELETE: api/v1/funds/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFondos(int id)
        {
            var result = await _fondosService.DeleteFondos(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
