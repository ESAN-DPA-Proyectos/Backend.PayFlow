using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.PayFlow.DOMAIN.Core.DTOs
{
    public class HistorialValidacionesResponseDTO
    {
        public int IdHistorial { get; set; }
        public string TipoValidacion { get; set; } = null!;
        public string? Resultado { get; set; }
        public string? Observacion { get; set; }
        public DateTime? FechaValidacion { get; set; }
        public int? ValidadoPor { get; set; }
    }
    public class HistorialValidacionesCreateDTO
    {
        public int? IdTransaccion { get; set; }
        public string TipoValidacion { get; set; } = null!;
        public string? Resultado { get; set; }
        public string? Observacion { get; set; }
        public int? ValidadoPor { get; set; }
    }
    public class HistorialValidacionesUpdateDTO
    {
        public string? Resultado { get; set; }
        public string? Observacion { get; set; }
        public DateTime? FechaValidacion { get; set; }
    }
}
