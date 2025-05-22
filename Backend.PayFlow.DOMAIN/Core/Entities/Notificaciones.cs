using System;
using System.Collections.Generic;

namespace Backend.PayFlow.DOMAIN.Core.Entities;

public partial class Notificaciones
{
    public int IdNotificacion { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdTransaccion { get; set; }

    public string TipoNotificacion { get; set; } = null!;

    public string? Mensaje { get; set; }

    public string? Estado { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Transacciones? IdTransaccionNavigation { get; set; }

    public virtual Usuarios? IdUsuarioNavigation { get; set; }
}
