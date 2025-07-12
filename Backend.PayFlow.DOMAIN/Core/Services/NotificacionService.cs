using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;

namespace Backend.PayFlow.DOMAIN.Core.Services
{
    public class NotificacionService : INotificacionService
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
                TipoNotificacion = dto.TipoNotificacion, // corregido nombre del campo
                Mensaje = dto.Mensaje,
                Estado = dto.Estado,
                FechaCreacion = dto.FechaCreacion ?? DateTime.UtcNow
            };

            await _repository.CreateAsync(notificacion);
        }

        public async Task<IEnumerable<NotificacionDto>> GetAllAsync()
        {
            var notificaciones = await _repository.GetAllAsync();

            return notificaciones.Select(n => new NotificacionDto
            {
                IdNotificacion = n.IdNotificacion,
                TipoNotificacion = n.TipoNotificacion,
                Mensaje = n.Mensaje ?? string.Empty,
                Estado = n.Estado ?? string.Empty,
                FechaCreacion = n.FechaCreacion ?? DateTime.MinValue,
                NombreUsuario = n.IdUsuarioNavigation?.Nombre ?? "Sin usuario",
                MontoTransaccion = n.IdTransaccionNavigation?.Monto ?? 0,
                MetodoPago = n.IdTransaccionNavigation?.MetodoPago ?? "Desconocido"
            });
        }
    }
}
