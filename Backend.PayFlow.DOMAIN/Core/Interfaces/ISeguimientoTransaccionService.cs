using Backend.PayFlow.DOMAIN.Core.Entities;

namespace Backend.PayFlow.DOMAIN.Core.Interfaces
{
    public interface ISeguimientoTransaccionService
    {
        Task<SeguimientoTransaccion?> ActualizarSeguimientoTransaccionAsync(SeguimientoTransaccion seguimientoTransaccion);
        Task<SeguimientoTransaccion> AgregarSeguimientoTransaccionAsync(SeguimientoTransaccion seguimientoTransaccion);
        Task<bool> EliminarSeguimientoTransaccionAsync(int id);
        Task<SeguimientoTransaccion?> ObtenerSeguimientoTransaccionPorIdAsync(int id);
        Task<IEnumerable<SeguimientoTransaccion>> ObtenerTodosSeguimientoTransaccionesAsync();
    }
}