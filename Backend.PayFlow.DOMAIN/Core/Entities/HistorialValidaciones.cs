using System;
using System.Collections.Generic;

namespace Backend.PayFlow.DOMAIN.Core.Entities;

public partial class HistorialValidaciones
{
    public int IdHistorial { get; set; }

    public int? IdTransaccion { get; set; }

    public string TipoValidacion { get; set; } = null!;

    public string? Resultado { get; set; }

    public string? Observacion { get; set; }

    public DateTime? FechaValidacion { get; set; }

    public int? ValidadoPor { get; set; }

    public virtual Transacciones? IdTransaccionNavigation { get; set; }

    public virtual Usuarios? ValidadoPorNavigation { get; set; }
}



