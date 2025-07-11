using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.PayFlow.DOMAIN.Core.DTOs
{
    public class TransaccionesDTO
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
        public string? OrigenRol { get; set; }
    }

    public class TransaccionesListDTO
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
        public string? OrigenRol { get; set; }
    }

    public class TransaccionesCreateDTO
    {
        public string Tipo { get; set; } = null!;
        public decimal Monto { get; set; }
        public string Estado { get; set; } = null!;
        public string? MetodoPago { get; set; }
        public string? BeneficiarioNombre { get; set; }
        public string? CuentaBeneficiario { get; set; }
        public string? Concepto { get; set; }
        public string? Referencia { get; set; }
        public string? Comprobante { get; set; }
        public string? OrigenRol { get; set; }
    }
}
