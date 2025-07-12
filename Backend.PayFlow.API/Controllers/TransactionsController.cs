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
        // Upload comprobante
        [HttpPost("upload-comprobante")]
        public async Task<IActionResult> UploadComprobante(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No se proporcionó ningún archivo.");
            }

            var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "comprobantes");

            if (!Directory.Exists(uploadsPath))
            {
                Directory.CreateDirectory(uploadsPath);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsPath, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var publicUrl = $"{Request.Scheme}://{Request.Host}/comprobantes/{uniqueFileName}";
            return Ok(new { url = publicUrl });
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

        // Get transaction by IdUsuario
        [HttpGet("Usu/{id:int}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetTransaccionesByUsu(int id)
        {
            var transacciones = await _transaccionesService.GetTransaccionesByUsu(id);
            if (transacciones == null)
            {
                return NotFound();
            }
            return Ok(transacciones);
        }
    }
}