using System;
using System.Collections.Generic;

namespace Backend.PayFlow.DOMAIN.Core.Entities;

public partial class Usuarios
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string? Usuario { get; set; }

    public string ContrasenaHash { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<HistorialSesiones> HistorialSesiones { get; set; } = new List<HistorialSesiones>();

    public virtual ICollection<HistorialValidaciones> HistorialValidaciones { get; set; } = new List<HistorialValidaciones>();

    public virtual ICollection<Notificaciones> Notificaciones { get; set; } = new List<Notificaciones>();

    public virtual ICollection<Transacciones> Transacciones { get; set; } = new List<Transacciones>();

    public virtual ICollection<Roles> IdRol { get; set; } = new List<Roles>();
}
