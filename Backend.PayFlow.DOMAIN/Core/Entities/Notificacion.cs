namespace Backend.PayFlow.DOMAIN.Core.Entities
{
    public class Notificacion
    {
        public int IdNotificacion { get; set; }

        public int? IdUsuario { get; set; }
        public int? IdTransaccion { get; set; }

        public string TipoNotificacion { get; set; } = null!; // ⚠️ corregido: antes decía "TipoNotification"
        public string? Mensaje { get; set; }
        public string? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }

        // Relaciones de navegación (opcional pero recomendado)
        public virtual Usuarios? IdUsuarioNavigation { get; set; }
        public virtual Transacciones? IdTransaccionNavigation { get; set; }
    }
}
