using System;
using System.Collections.Generic;

namespace Backend.PayFlow.DOMAIN.Core.Entities;

public partial class HistorialSesiones
{
    public int IdSesion { get; set; }

    public int? IdUsuario { get; set; }

    public DateTime? FechaHora { get; set; }

    public string? TipoAcceso { get; set; }

    public string? DireccionIp { get; set; }

    public virtual Usuarios? IdUsuarioNavigation { get; set; }
}
