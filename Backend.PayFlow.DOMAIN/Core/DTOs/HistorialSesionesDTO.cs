using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.PayFlow.DOMAIN.Core.DTOs
{
    public class HistorialSesionesDTO
    {
        public int IdSesion { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaHora { get; set; }
        public string? TipoAcceso { get; set; }
        public string? DireccionIP { get; set; }

    }

    public class HistorialSesionesCreateDTO
    {
        public int IdUsuario { get; set; }
        public DateTime FechaHora { get; set; }
        public string? TipoAcceso { get; set; }
        public string? DireccionIP { get; set; }
    }
}
