using System;
using System.Collections.Generic;

namespace Backend.PayFlow.DOMAIN.Core.Entities;

public partial class Roles
{
    public int IdRol { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Usuarios> IdUsuario { get; set; } = new List<Usuarios>();
}
