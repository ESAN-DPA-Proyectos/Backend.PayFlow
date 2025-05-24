using Backend.PayFlow.DOMAIN.Core.Entities;

namespace Backend.PayFlow.DOMAIN.Core.Interfaces
{
    public interface IRolesRepository
    {
        Task<int> AddRoleAsync(Roles role);
        Task<bool> DeleteRoles(int id);
        Task<IEnumerable<Roles>> GetAllRoles();
        Task<Roles> GetRoleById(int id);
        Task<bool> RemoveRoles(int id);
        Task<bool> UpdateRoles(Roles role);
    }
}