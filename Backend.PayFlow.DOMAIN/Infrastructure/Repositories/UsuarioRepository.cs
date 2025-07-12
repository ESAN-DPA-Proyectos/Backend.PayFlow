using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Backend.PayFlow.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.PayFlow.DOMAIN.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PayFlowDbContext _context;

        public UsuarioRepository(PayFlowDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuarios>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuarios?> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<Usuarios?> GetByCorreoAsync(string correo)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == correo);
        }
        /* Select */
        public async Task<IEnumerable<UsuarioDto>> GetByDNIAsync(string DNI)
        {
            /* busca todos */
            return await _context.Usuarios.Select(u => new UsuarioDto
            {
                IdUsuario = u.IdUsuario,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                DNI = u.Dni,
                Correo = u.Correo,
                Usuario = u.Usuario,
                FechaRegistro = u.FechaRegistro ?? DateTime.MinValue,
                Estado = u.Estado
            }
                ).Where(r => r.DNI.Contains(DNI)).ToListAsync();


        }
        public async Task<Usuarios?> GetByUsuarioAsync(string username)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Usuario == username);
        }

        public async Task<bool> RegisterAsync(Usuarios usuario)
        {
            _context.Usuarios.Add(usuario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Usuarios usuario)
        {
            _context.Usuarios.Update(usuario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.IdRol) // Incluir los roles para poder eliminarlos
                .FirstOrDefaultAsync(u => u.IdUsuario == id);

            if (usuario == null)
                return false;

            // Limpiar la relación con los roles (tabla intermedia UsuarioRoles)
            usuario.IdRol.Clear();

            // Eliminar relaciones adicionales si es necesario
            var historialSesiones = _context.HistorialSesiones.Where(h => h.IdUsuario == id);
            _context.HistorialSesiones.RemoveRange(historialSesiones);

            var validaciones = _context.HistorialValidaciones
                .Include(h => h.IdTransaccionNavigation)
                .Where(h => h.IdTransaccionNavigation.IdUsuario == id);
            _context.HistorialValidaciones.RemoveRange(validaciones);

            var notificaciones = _context.Notificaciones.Where(n => n.IdUsuario == id);
            _context.Notificaciones.RemoveRange(notificaciones);

            var transacciones = _context.Transacciones.Where(t => t.IdUsuario == id);
            _context.Transacciones.RemoveRange(transacciones);

            // Guardar cambios para eliminar relaciones
            await _context.SaveChangesAsync();
           
            var validacionesComoValidador = _context.HistorialValidaciones
                .Where(h => h.ValidadoPor == id);
            _context.HistorialValidaciones.RemoveRange(validacionesComoValidador);
            // Ahora eliminar el usuario
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CambiarContrasenaAsync(int idUsuario, string nuevaContrasenaHash)
        {
            var usuario = await _context.Usuarios.FindAsync(idUsuario);
            if (usuario == null) return false;

            usuario.ContrasenaHash = nuevaContrasenaHash;
            _context.Usuarios.Update(usuario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ExistsByCorreoAsync(string correo)
        {
            return await _context.Usuarios.AnyAsync(u => u.Correo == correo);
        }

        public async Task<bool> ExistsByUsuarioAsync(string username)
        {
            return await _context.Usuarios.AnyAsync(u => u.Usuario == username);
        }
        public async Task<IEnumerable<UsuarioDto>> ListarUsuariosAsync()
        {
            return await _context.Usuarios
                .Select(u => new UsuarioDto
                {
                    IdUsuario = u.IdUsuario,
                    Nombre = u.Nombre,
                    Apellido = u.Apellido,
                    Correo = u.Correo,
                    Usuario = u.Usuario,
                    FechaRegistro = u.FechaRegistro ?? DateTime.MinValue,
                    Estado = u.Estado
                })
                .ToListAsync();
        }
    }
}
