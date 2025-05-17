using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayFlow.API.Models;

namespace PayFlow.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TransaccionesController : ControllerBase
    {
        private readonly PayFlowContext _context;

        public TransaccionesController(PayFlowContext context)
        {
            _context = context;
        }

        // GET: api/Transacciones xxx
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transacciones>>> GetTransacciones()
        {
            return await _context.Transacciones.ToListAsync();
        }

        // GET: api/Transacciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transacciones>> GetTransacciones(int id)
        {
            var transacciones = await _context.Transacciones.FindAsync(id);

            if (transacciones == null)
            {
                return NotFound();
            }

            return transacciones;
        }

        // PUT: api/Transacciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransacciones(int id, Transacciones transacciones)
        {
            if (id != transacciones.IdTransaccion)
            {
                return BadRequest();
            }

            _context.Entry(transacciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransaccionesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Transacciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transacciones>> PostTransacciones(Transacciones transacciones)
        {
            _context.Transacciones.Add(transacciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransacciones", new { id = transacciones.IdTransaccion }, transacciones);
        }

        // DELETE: api/Transacciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransacciones(int id)
        {
            var transacciones = await _context.Transacciones.FindAsync(id);
            if (transacciones == null)
            {
                return NotFound();
            }

            _context.Transacciones.Remove(transacciones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransaccionesExists(int id)
        {
            return _context.Transacciones.Any(e => e.IdTransaccion == id);
        }
    }
}
