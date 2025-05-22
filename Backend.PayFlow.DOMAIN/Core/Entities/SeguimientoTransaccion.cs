using System;
using System.Collections.Generic;

namespace Backend.PayFlow.DOMAIN.Core.Entities;

public partial class SeguimientoTransaccion
{
    public int IdSeguimiento { get; set; }

    public int? IdTransaccion { get; set; }

    public string? Hito { get; set; }

    public DateTime? FechaHora { get; set; }

    public string? Estado { get; set; }

    public virtual Transacciones? IdTransaccionNavigation { get; set; }
}
