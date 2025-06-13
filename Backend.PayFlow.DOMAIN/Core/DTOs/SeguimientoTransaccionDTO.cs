using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.PayFlow.DOMAIN.Core.DTOs
{
    public class SeguimientoTransaccionResponseDTO
    {
        public int idSeguimiento { get; set; }
        public int? idTransaccion { get; set; }
        public string? hito { get; set; }
        public DateTime? fechaHora { get; set; }
        public string? estado { get; set; }
    }

    public class SeguimientoTransaccionCreateDTO
    {
        public int? idTransaccion { get; set; }
        public string? hito { get; set; }
        public DateTime? fechaHora { get; set; }
        public string? estado { get; set; }
    }

    public class SeguimientoTransaccionUpdateDTO
    {
        public int idSeguimiento { get; set; }
        public int? idTransaccion { get; set; }
        public string? hito { get; set; }
        public DateTime? fechaHora { get; set; }
        public string? estado { get; set; }

    }
}
