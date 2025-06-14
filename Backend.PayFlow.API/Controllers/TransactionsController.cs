using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.PayFlow.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        //private readonly ITransaccionesRepository _transaccionesRepository;
        //public TransactionsController(ITransaccionesRepository transaccionesRepository)
        //{
        //    _transaccionesRepository = transaccionesRepository;
        //}
        private readonly ITransaccionesService _transaccionesService;
        public TransactionsController(ITransaccionesService transaccionesService)
        {
            _transaccionesService = transaccionesService;
        }
        // Get all transactions
        [HttpGet]
        public async Task<IActionResult> GetAllTransactions()
        {
            var transactions = await _transaccionesService.GetAllTransactions();
            return Ok(transactions);
        }
        // Get transaction by IdTransaccion
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTransaccionesById(int id)
        {
            var transacciones = await _transaccionesService.GetTransaccionesById(id);
            if (transacciones == null)
            {
                return NotFound();
            }
            return Ok(transacciones);
        }
        // Add transacción
        [HttpPost]
        public async Task<IActionResult> AddTransacciones([FromBody] TransaccionesCreateDTO transaccionesCreateDTO)
        {
            if (transaccionesCreateDTO == null)
            {
                return BadRequest("Transaction data is null.");
            }
            var transaccionesId = await _transaccionesService.AddTransacciones(transaccionesCreateDTO);
            return CreatedAtAction(nameof(GetTransaccionesById), new { id = transaccionesId}, transaccionesCreateDTO);

        }
        // Update transacción
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTransacciones(int id, [FromBody] TransaccionesListDTO transaccionesListDTO)
        {
            if (id != transaccionesListDTO.IdTransaccion)
            {
                return BadRequest("Transaction data is invalid.");
            }
            var result = await _transaccionesService.UpdateTransacciones(transaccionesListDTO);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        // Delete transacción (no implementado, pero puede ser adicionado después)
    }
}