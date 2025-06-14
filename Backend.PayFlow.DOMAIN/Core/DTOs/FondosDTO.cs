using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.PayFlow.DOMAIN.Core.DTOs
{
    public class FondosDTO
    {
        public int IdFondo { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public decimal? AportePorAsociado { get; set; }

        public decimal? Meta { get; set; }

        public decimal? SaldoActual { get; set; }

        public string? Estado { get; set; }
    }
}
