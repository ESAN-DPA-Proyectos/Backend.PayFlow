using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Backend.PayFlow.DOMAIN.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.PayFlow.DOMAIN.Infrastructure.Repositories
{
    public class UsuarioRolRepository : IUsuarioRolRepository
    {
        private readonly PayFlowDbContext _context;

        public UsuarioRolRepository(PayFlowDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AsignarAsync(int idUsuario, int idRol)
        {
            var existe = await _context.Set<Dictionary<string, object>>("UsuarioRoles")
                .FindAsync(idUsuario, idRol);

            if (existe != null) return true;

            var fila = new Dictionary<string, object>
            {
                ["IdUsuario"] = idUsuario,
                ["IdRol"] = idRol
            };

            _context.Set<Dictionary<string, object>>("UsuarioRoles").Add(fila);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
