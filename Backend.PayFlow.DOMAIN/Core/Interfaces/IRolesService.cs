using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Entities;

namespace Backend.PayFlow.DOMAIN.Core.Interfaces
{
    public interface IRolesService
    {
        Task<bool> ActualizarRol(Roles rol);
        Task<Roles> BuscarRolPorId(int id);
        Task<bool> DeleteRol(int id);
        Task<IEnumerable<RolesDTO>> ListarRoles();
        Task<bool> RegistrarRol(RolesCreateDTO dto);
        Task<bool> RemoveRol(int id);
    }
}