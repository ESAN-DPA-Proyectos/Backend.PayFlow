using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Backend.PayFlow.DOMAIN.Infrastructure.Data;
using Backend.PayFlow.DOMAIN.Infrastructure.Repositories;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Backend.PayFlow.DOMAIN.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly PayFlowDbContext _context;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(PayFlowDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegistrarUsuarioAsync(UsuarioDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Contrasena))
                throw new ArgumentException("La contraseña no puede ser nula o vacía.");

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

        public async Task<bool> CambiarContrasenaAsync(UsuarioDto dto)
        {
            var usuario = await _context.Usuarios.FindAsync(dto.IdUsuario);
            if (usuario == null || string.IsNullOrWhiteSpace(dto.NuevaContrasena))
                return false;

            usuario.ContrasenaHash = HashPassword(dto.NuevaContrasena);
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

        private string HashPassword(string password)
        {
            // Usamos un salt fijo para permitir comparaciones (solo para pruebas)
            byte[] salt = Encoding.UTF8.GetBytes("saltfijo");

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }
        public async Task<IEnumerable<UsuarioDto>> GetByDNIAsync(string DNI)
        {
            var usuarios = await _context.Usuarios
                .Where(u => u.Dni == DNI)
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

            return usuarios;
        }
        public async Task<UsuarioDto?> ValidarCredencialesAsync(string nombreUsuario, string contrasena)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Usuario == nombreUsuario);

            if (usuario == null)
                return null;

            var hashIngresado = HashPassword(contrasena);

            if (hashIngresado != usuario.ContrasenaHash)
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
    }
}
