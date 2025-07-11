using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;


namespace Backend.PayFlow.DOMAIN.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuarios>> GetAllAsync();
        Task<Usuarios?> GetByIdAsync(int id);
        Task<Usuarios?> GetByCorreoAsync(string correo);
        Task<IEnumerable<UsuarioDto>> GetByDNIAsync(string DNI);
        Task<Usuarios?> GetByUsuarioAsync(string username);
        Task<bool> RegisterAsync(Usuarios usuario);
        Task<bool> UpdateAsync(Usuarios usuario);
        Task<bool> DeleteAsync(int id);
        Task<bool> CambiarContrasenaAsync(int idUsuario, string nuevaContrasenaHash);
        Task<bool> ExistsByCorreoAsync(string correo);
        Task<bool> ExistsByUsuarioAsync(string username);
    }
}
