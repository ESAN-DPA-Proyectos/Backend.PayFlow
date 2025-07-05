using Backend.PayFlow.DOMAIN.Core.DTOs;

namespace Backend.PayFlow.DOMAIN.Core.Interfaces
{
    public interface INotificacionService
    {
        Task CreateAsync(CreateNotificationDTO dto);
        Task<IEnumerable<NotificacionDto>> GetAllAsync();
    }
}
