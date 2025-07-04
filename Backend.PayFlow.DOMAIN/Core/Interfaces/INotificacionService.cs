using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Entities;

namespace Backend.PayFlow.DOMAIN.Core.Interfaces
{
    public interface INotificacionService
    {
        Task CreateAsync(CreateNotificationDTO dto);
        Task<IEnumerable<Notificacion>> GetAllAsync();
    }
}
