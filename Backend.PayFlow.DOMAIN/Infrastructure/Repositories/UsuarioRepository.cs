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
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            return await _context.SaveChangesAsync() > 0;
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
    }
}
