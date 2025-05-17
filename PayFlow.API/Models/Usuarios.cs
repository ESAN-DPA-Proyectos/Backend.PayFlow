using System;
using System.Collections.Generic;

namespace PayFlow.API.Models;

public partial class Usuarios
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string ContrasenaHash { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public int? IdRol { get; set; }

    public string Estado { get; set; } = null!;

    public string? Alias { get; set; }

    public virtual Roles? IdRolNavigation { get; set; }

    public virtual ICollection<Transacciones> Transacciones { get; set; } = new List<Transacciones>();

    public virtual ICollection<Validaciones> Validaciones { get; set; } = new List<Validaciones>();
}
