using Backend.PayFlow.DOMAIN.Core.Entities;

namespace Backend.PayFlow.DOMAIN.Core.Interfaces
{
    public interface INotificacionRepository
    {
        Task CreateAsync(Notificacion notificacion);
    }
}
