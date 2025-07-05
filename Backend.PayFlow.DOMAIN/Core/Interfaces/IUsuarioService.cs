using Backend.PayFlow.DOMAIN.Core.DTOs;

namespace Backend.PayFlow.DOMAIN.Core.Interfaces
{
    public interface IUsuarioService
    {
        Task<bool> RegistrarUsuarioAsync(UsuarioDto dto);
        Task<bool> CambiarContrasenaAsync(UsuarioDto dto);
        Task<UsuarioDto?> ObtenerUsuarioPorIdAsync(int id);
        Task<IEnumerable<UsuarioDto>> ObtenerTodosLosUsuariosAsync();
    }
}
