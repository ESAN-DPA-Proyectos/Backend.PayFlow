using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Backend.PayFlow.DOMAIN.Infrastructure.Data;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
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
