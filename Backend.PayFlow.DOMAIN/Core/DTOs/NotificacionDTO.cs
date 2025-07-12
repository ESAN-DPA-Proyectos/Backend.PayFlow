namespace Backend.PayFlow.DOMAIN.Core.DTOs
{
    public class NotificacionDto
    {
        public int IdNotificacion { get; set; }
        public string TipoNotificacion { get; set; } = string.Empty;
        public string Mensaje { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public decimal MontoTransaccion { get; set; }
        public string MetodoPago { get; set; } = string.Empty;
    }
}
