namespace Backend.PayFlow.DOMAIN.Core.DTOs
{
    public class CreateNotificationDTO
    {
        public int? IdUsuario { get; set; }
        public int? IdTransaccion { get; set; }

        // Alineado al campo real de la entidad (Notificacion.cs)
        public string TipoNotificacion { get; set; } = string.Empty;

        public string? Mensaje { get; set; }
        public string? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
