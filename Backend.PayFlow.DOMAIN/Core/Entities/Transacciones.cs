using System;
using System.Collections.Generic;

namespace Backend.PayFlow.DOMAIN.Core.Entities;

public partial class Transacciones
{
    public int IdTransaccion { get; set; }

    public string Tipo { get; set; } = null!;

    public decimal Monto { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public string Estado { get; set; } = null!;

    public string? MetodoPago { get; set; }

    public string? BeneficiarioNombre { get; set; }

    public string? CuentaBeneficiario { get; set; }

    public string? Concepto { get; set; }

    public string? Referencia { get; set; }

    public string? Comprobante { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdFondo { get; set; }

    public string? OrigenRol { get; set; }

    public virtual ICollection<HistorialValidaciones> HistorialValidaciones { get; set; } = new List<HistorialValidaciones>();

    public virtual Fondos? IdFondoNavigation { get; set; }

    public virtual Usuarios? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Notificacion> Notificaciones { get; set; } = new List<Notificacion>();

    public virtual ICollection<SeguimientoTransaccion> SeguimientoTransaccion { get; set; } = new List<SeguimientoTransaccion>();
}
