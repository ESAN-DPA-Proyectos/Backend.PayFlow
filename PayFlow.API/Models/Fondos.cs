using System;
using System.Collections.Generic;

namespace PayFlow.API.Models;

public partial class Fondos
{
    public int IdFondo { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal? AportePorAsociado { get; set; }

    public decimal? Meta { get; set; }

    public decimal? SaldoActual { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Transacciones> Transacciones { get; set; } = new List<Transacciones>();
}
