using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Backend.PayFlow.DOMAIN.Core.Services;
using Backend.PayFlow.DOMAIN.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.PayFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialSesionesController : ControllerBase
    {
        private readonly IHistorialSesionesService _HSService;

        public HistorialSesionesController(IHistorialSesionesService HSService)
        {
            _HSService = HSService;
        }


        // GET: api/HistSesion
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var hs = await _HSService.ListarHistSesion();
            return Ok(hs);
        }


        // GET: api/HistSesion/login
        [HttpGet("{TipAcceso}")]
        public async Task<IActionResult> Get(string TipAcceso)
        {
            var hs = await _HSService.BuscarHistSesionPorTipAsc(TipAcceso);

            if (hs == null)
                return NotFound(new { message = "Historial de Sesiones no encontrado." });

            return Ok(hs);
        }


        // POST: api/HistSesion
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HistorialSesionesCreateDTO dto)
        {
            var resultado = await _HSService.RegistrarHistSesion(dto);

            if (resultado)
                return Ok(new
                {
                    resultado,
                    message = "Historial de Sesiones registrado exitosamente.",
                    dto
                }
                );

            return StatusCode(500, new { message = "Error al registrar el Historial de Sesiones." });
        }


    }
}
