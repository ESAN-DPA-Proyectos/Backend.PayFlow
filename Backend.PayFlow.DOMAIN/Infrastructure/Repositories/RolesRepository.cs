using Backend.PayFlow.DOMAIN.Core.DTOs;
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

        /******************************************************************/
        private bool RoleExists(int id)
        {
            return _context.Roles.Any(e => e.IdRol == id);
        }
        /******************************************************************/

        /* Insert */
        public async Task<bool> RegistrarRol(RolesCreateDTO dto)
        {
            var rol = new Roles
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion
            };

            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();
            return true;
        }

        /* Update */
        public async Task<bool> ActualizarRol(Roles rol)
        {
            bool result;

            _context.Entry(rol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                result = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(rol.IdRol))
                {
                    result = false;
                }
                else
                {
                    throw;
                }
            }

            return result;
        }


        /* Delete */
        public async Task<bool> DeleteRol(int id)
        {
            var rol = await _context.Roles.FindAsync(id);

            return true;
        }

        /* Remove */
        public async Task<bool> RemoveRol(int id)
        {
            bool result;
            /* Busca el rol en el contexto */
            //var rol = await _context.Roles.FindAsync(id);

            /* Y como la funcion devuelve el objeto en el contexto golbal,
             * se puede usar sin problemas */
            var rol = await BuscarRolPorId(id);

            if (rol == null)
            {
                result = false;
            }
            else
            {
                try
                {
                    _context.Roles.Remove(rol);
                    await _context.SaveChangesAsync();

                    result = true;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoleExists(rol.IdRol))
                    {
                        result = false;
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            return result;
        }


        /* Select */
        public async Task<IEnumerable<RolesDTO>> ListarRoles()
        {
            return await _context.Roles.Select(rol => new RolesDTO
            {
                IdRol = rol.IdRol,
                Nombre = rol.Nombre,
                Descripcion = rol.Descripcion
            }
                ).ToListAsync();
        }

        /* Select */
        public async Task<Roles> BuscarRolPorId(int id)
        {
            var rol = await _context.Roles.FindAsync(id);

            if (rol == null)
            {
                return null;
            }
            else
            {
                return rol;
                /* Es mejor devolver el mismo rol 
                 * para poder conservar el objeto en el contexto global */

                /*
                return new Roles
                {
                    IdRol = rol.IdRol,
                    Nombre = rol.Nombre,
                    Descripcion = rol.Descripcion
                };
                */
            }
        }
    }
}
