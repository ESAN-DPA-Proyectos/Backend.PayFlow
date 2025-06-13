using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.PayFlow.DOMAIN.Core.Services
{
    public class TransaccionesService : ITransaccionesService
    {
        private readonly ITransaccionesRepository _transaccionesRepository;

        public TransaccionesService(ITransaccionesRepository transaccionesRepository)
        {
            _transaccionesRepository = transaccionesRepository;
        }

        public async Task<IEnumerable<TransaccionesListDTO>> GetAllTransactions()
        {
            var transactions = await _transaccionesRepository.GetAllTransactions();
            var transactionsDTO = transactions.Select(t => new TransaccionesListDTO
            {
                IdTransaccion = t.IdTransaccion,
                Tipo = t.Tipo,
                Monto = t.Monto,
                FechaRegistro = t.FechaRegistro,
                Estado = t.Estado,
                MetodoPago = t.MetodoPago,
                BeneficiarioNombre = t.BeneficiarioNombre,
                CuentaBeneficiario = t.CuentaBeneficiario,
                Concepto = t.Concepto,
                Referencia = t.Referencia,
                Comprobante = t.Comprobante,
                OrigenRol = t.OrigenRol
            });

            return transactionsDTO;

        }

        public async Task<TransaccionesListDTO> GetTransaccionesById(int id)
        {
            var transacciones = await _transaccionesRepository.GetTransaccionesById(id);
            if (transacciones == null)
            {
                return null;
            }
            var transaccionesDTO = new TransaccionesListDTO
            {
                IdTransaccion = transacciones.IdTransaccion,
                Tipo = transacciones.Tipo,
                Monto = transacciones.Monto,
                FechaRegistro = transacciones.FechaRegistro,
                Estado = transacciones.Estado,
                MetodoPago = transacciones.MetodoPago,
                BeneficiarioNombre = transacciones.BeneficiarioNombre,
                CuentaBeneficiario = transacciones.CuentaBeneficiario,
                Concepto = transacciones.Concepto,
                Referencia = transacciones.Referencia,
                Comprobante = transacciones.Comprobante,
                OrigenRol = transacciones.OrigenRol
            };
            return transaccionesDTO;
        }

        public async Task<int> AddTransacciones(TransaccionesCreateDTO transaccionesDTO)
        {
            var transacciones = new Transacciones
            {
                Tipo = transaccionesDTO.Tipo,
                Monto = transaccionesDTO.Monto,
                Estado = transaccionesDTO.Estado,
                MetodoPago = transaccionesDTO.MetodoPago,
                BeneficiarioNombre = transaccionesDTO.BeneficiarioNombre,
                CuentaBeneficiario = transaccionesDTO.CuentaBeneficiario,
                Concepto = transaccionesDTO.Concepto,
                Comprobante = transaccionesDTO.Comprobante,
                OrigenRol = transaccionesDTO.OrigenRol,
            };
            return await _transaccionesRepository.AddTransacciones(transacciones);
        }
        // Actualizar una transacción existente
        public async Task<bool> UpdateTransacciones(TransaccionesListDTO transaccionesDTO)
        {
            var transacciones = new Transacciones
            {
                IdTransaccion = transaccionesDTO.IdTransaccion,
                Tipo = transaccionesDTO.Tipo,
                Monto = transaccionesDTO.Monto,
                Estado = transaccionesDTO.Estado,
                MetodoPago = transaccionesDTO.MetodoPago,
                BeneficiarioNombre = transaccionesDTO.BeneficiarioNombre,
                CuentaBeneficiario = transaccionesDTO.CuentaBeneficiario,
                Concepto = transaccionesDTO.Concepto,
                Comprobante = transaccionesDTO.Comprobante,
                OrigenRol = transaccionesDTO.OrigenRol,
            };
            return await _transaccionesRepository.UpdateTransacciones(transacciones);
        }
        // Eliminar no implementado en el repositorio (regla de negocio), pero se puede agregar si es necesario
    }
}
