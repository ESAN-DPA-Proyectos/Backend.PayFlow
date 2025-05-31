using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.PayFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialValidacionesController : ControllerBase
    {
        private readonly PayFlowDbContext _context;

        public HistorialValidacionesController(PayFlowDbContext context)
        {
            _context = context;
        }


        // GET: api/HistValid
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialValidaciones>>> GetAllHistValid()
        {
            return await _context.HistorialValidaciones.ToListAsync();
        }


        // GET: api/HistValid/Manual
        [HttpGet("{TipVal}")]
        public async Task<ActionResult<HistorialValidaciones>> GetHistValidByTipo(string TipoVal)
        {
            var hist_Valid = await _context.HistorialValidaciones.Where(c => c.TipoValidacion == TipoVal).FirstOrDefaultAsync();

            if (hist_Valid == null)
            {
                return NotFound();
            }

            return hist_Valid;
        }


        // POST: api/HistValid
        [HttpPost]
        public async Task<ActionResult<Roles>> PostHistValid(HistorialValidaciones hist_Valid)
        {
            _context.HistorialValidaciones.Add(hist_Valid);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllHistValid", new { id = hist_Valid.IdHistorial }, hist_Valid);
        }


    }
}
