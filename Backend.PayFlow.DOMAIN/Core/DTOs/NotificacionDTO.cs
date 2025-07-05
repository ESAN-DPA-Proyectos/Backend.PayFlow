namespace Backend.PayFlow.DOMAIN.Core.DTOs
{
    public class NotificacionDto
    {
        public int IdNotificacion { get; set; }
        public string TipoNotificacion { get; set; } = string.Empty;
        public string Mensaje { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
    }
}
