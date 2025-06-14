﻿namespace Backend.PayFlow.DOMAIN.Core.DTOs
{
    public class CreateNotificationDTO
    {
        public int? IdUsuario { get; set; }
        public int? IdTransaccion { get; set; }
        public string TipoNotification { get; set; } = null!;
        public string? Mensaje { get; set; }
        public string? Estado { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
