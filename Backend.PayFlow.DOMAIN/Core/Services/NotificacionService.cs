using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;

namespace Backend.PayFlow.DOMAIN.Core.Services
{
    public class NotificacionService
    {
        private readonly INotificacionRepository _repository;

        public NotificacionService(INotificacionRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(CreateNotificationDTO dto)
        {
            var notificacion = new Notificacion
            {
                IdUsuario = dto.IdUsuario,
                IdTransaccion = dto.IdTransaccion,
                TipoNotification = dto.TipoNotification,
                Mensaje = dto.Mensaje,
                Estado = dto.Estado,
                FechaCreacion = dto.FechaCreacion ?? DateTime.UtcNow
            };

            await _repository.CreateAsync(notificacion);
        }
    }
}
