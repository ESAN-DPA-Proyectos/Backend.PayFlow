using Backend.PayFlow.DOMAIN.Core.Entities;

namespace Backend.PayFlow.DOMAIN.Core.Interfaces
{
    public interface INotificacionRepository
    {
        Task<bool> CreateAsync(Notificacion notificacion);
        Task<IEnumerable<Notificacion>> GetAllAsync();
        Task<Notificacion?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(Notificacion notificacion);      // Añadir
        Task<bool> DeleteAsync(int id);                         // Añadir
    }
}
