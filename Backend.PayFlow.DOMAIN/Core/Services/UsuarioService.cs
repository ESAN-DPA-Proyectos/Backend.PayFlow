using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Backend.PayFlow.DOMAIN.Infrastructure.Data;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Backend.PayFlow.DOMAIN.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly PayFlowDbContext _context;

        public UsuarioService(PayFlowDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegistrarUsuarioAsync(UsuarioRegisterDto dto)
        {
            var usuario = new Usuarios
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Dni = dto.DNI,
                Correo = dto.Correo,
                Usuario = dto.Usuario,
                ContrasenaHash = HashPassword(dto.Contrasena),
                FechaRegistro = DateTime.UtcNow,
                Estado = "Activo",
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UsuarioDto?> ObtenerUsuarioPorIdAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                return null;

            return new UsuarioDto
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                DNI = usuario.Dni,
                Correo = usuario.Correo,
                Usuario = usuario.Usuario,
                FechaRegistro = usuario.FechaRegistro ?? DateTime.MinValue,
                Estado = usuario.Estado
            };
        }

        public async Task<IEnumerable<UsuarioDto>> ObtenerTodosLosUsuariosAsync()
        {
            return await _context.Usuarios
                .Select(usuario => new UsuarioDto
                {
                    IdUsuario = usuario.IdUsuario,
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    DNI = usuario.Dni,
                    Correo = usuario.Correo,
                    Usuario = usuario.Usuario,
                    FechaRegistro = usuario.FechaRegistro ?? DateTime.MinValue,
                    Estado = usuario.Estado
                })
                .ToListAsync();
        }

        public async Task<bool> CambiarContrasenaAsync(int idUsuario, string nuevaContrasena)
        {
            var usuario = await _context.Usuarios.FindAsync(idUsuario);
            if (usuario == null)
                return false;

            usuario.ContrasenaHash = HashPassword(nuevaContrasena);
            await _context.SaveChangesAsync();
            return true;
        }


        private string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }
    }
}
