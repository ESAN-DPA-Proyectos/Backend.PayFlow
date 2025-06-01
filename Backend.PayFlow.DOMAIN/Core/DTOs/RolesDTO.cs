using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.PayFlow.DOMAIN.Core.DTOs
{
    public class RolesDTO
    {
        public int IdRol { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }

    public class RolesCreateDTO
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
}
