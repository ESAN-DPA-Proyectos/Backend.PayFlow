using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Entities;

namespace Backend.PayFlow.DOMAIN.Core.Interfaces
{
    public interface IRolesRepository
    {
        Task<IEnumerable<Roles>> GetAllRoles();
        Task<Roles> GetRoleById(int id);
        Task<int> AddRole(Roles role);
        Task<bool> UpdateRoles(Roles role);
        Task<bool> DeleteRoles(int id);
        Task<bool> RemoveRoles(int id);
        //
    }
}