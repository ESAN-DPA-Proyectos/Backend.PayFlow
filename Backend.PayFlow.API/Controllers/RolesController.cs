using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Backend.PayFlow.DOMAIN.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.PayFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly PayFlowDbContext _context;

        public RolesController(PayFlowDbContext context)
        {
            _context = context;
        }


        /******************************************************************/
        private bool RoleExists(int id)
        {
            return _context.Roles.Any(e => e.IdRol == id);
        }
        /******************************************************************/


        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Roles>>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }



        // GET: api/Roles/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Roles>> GetRoleById222(int id)
        {
            var role = await _context.Roles.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }


        // POST: api/Roles
        [HttpPost]
        public async Task<ActionResult<Roles>> AddRole(Roles role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAllRoles", new { id = role.IdRol }, role);
        }


        // PUT: api/Roles
        [HttpPut]
        public async Task<IActionResult> UpdateRoles(Roles role)
        {
            _context.Entry(role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(role.IdRol))
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


        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoles(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return NoContent();
            //return CreatedAtAction("GetAllRoles", new { id = role.IdRol }, role);
        }



    }
}
