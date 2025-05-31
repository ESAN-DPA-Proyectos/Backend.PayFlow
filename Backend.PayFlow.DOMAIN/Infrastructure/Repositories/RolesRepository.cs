using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Backend.PayFlow.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.PayFlow.DOMAIN.Infrastructure.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly PayFlowDbContext _context;

        public RolesRepository(PayFlowDbContext context)
        {
            _context = context;
        }

        // Get all roles
        public async Task<IEnumerable<Roles>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        // Get role by id
        public async Task<Roles> GetRoleById(int id)
        {
            return await _context.Roles.Where(c => c.IdRol == id).FirstOrDefaultAsync();
        }

        // Add a new role
        public async Task<int> AddRole(Roles role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return role.IdRol;
        }

        // Update role
        public async Task<bool> UpdateRoles(Roles role)
        {
            var existingRoles = await GetRoleById(role.IdRol);
            if (existingRoles == null)
            {
                return false;
            }
            existingRoles.Nombre = role.Nombre;
            existingRoles.Descripcion = role.Descripcion;

            _context.Roles.Update(existingRoles);
            await _context.SaveChangesAsync();
            return true;
        }

        //Delete role
        public async Task<bool> DeleteRoles(int id)
        {
            var role = await GetRoleById(id);
            if (role == null)
            {
                return false;
            }
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return true;
        }

        // Delete role by id (remove)
        public async Task<bool> RemoveRoles(int id)
        {
            var role = await GetRoleById(id);
            if (role == null)
            {
                return false;
            }
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }

        //

    }
}
