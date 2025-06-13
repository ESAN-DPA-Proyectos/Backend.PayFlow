using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Backend.PayFlow.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.PayFlow.DOMAIN.Infrastructure.Repositories
{
    public class TransaccionesRepository : ITransaccionesRepository
    {
        private readonly PayFlowDbContext _context;

        public TransaccionesRepository(PayFlowDbContext context)
        {
            _context = context;
        }

        // Get all transactions
        public async Task<IEnumerable<Transacciones>> GetAllTransactions()
        {
            return await _context.Transacciones.ToListAsync();
        }

        // Get transacción by IdTransaccion
        public async Task<Transacciones?> GetTransaccionesById(int id)
        {
            return await _context.Transacciones
                .Where(t => t.IdTransaccion == id)
                .FirstOrDefaultAsync();
        }

        // Add category
        
        public async Task<int> AddTransacciones(Transacciones transacciones)
        {
            await _context.Transacciones.AddAsync(transacciones);
            await _context.SaveChangesAsync();
            return transacciones.IdTransaccion;

        }

        // Update transacción
        public async Task<bool> UpdateTransacciones(Transacciones transacciones)
        {
            var existingTransacciones = await GetTransaccionesById(transacciones.IdTransaccion);
            //var existingTransacciones = await _context.Transacciones.FindAsync(transacciones.IdTransaccion);
            if (existingTransacciones == null)
            {
                return false;
            }
            existingTransacciones.Tipo = transacciones.Tipo;
            existingTransacciones.Monto = transacciones.Monto;
            //existingTransacciones.FechaRegistro = transacciones.FechaRegistro; //No debe ser cambiado
            existingTransacciones.Estado = transacciones.Estado;
            existingTransacciones.MetodoPago = transacciones.MetodoPago;

            existingTransacciones.BeneficiarioNombre = transacciones.BeneficiarioNombre; //Añadido para incluir el nombre del beneficiario
            existingTransacciones.CuentaBeneficiario = transacciones.CuentaBeneficiario; //Añadido para incluir la cuenta del beneficiario
            existingTransacciones.Concepto = transacciones.Concepto; //Añadido para incluir el concepto de la transacción
            //existingTransacciones.Referencia = transacciones.Referencia; //Añadido para incluir la referencia de la transacción
            existingTransacciones.Comprobante = transacciones.Comprobante; //Añadido para incluir el comprobante de la transacción

            //_context.Transacciones.Update(existingTransacciones);
            await _context.SaveChangesAsync();
            return true;
        }

        //Delete transacción - Por regla de negocio, no se elimina una transacción.





    }

}


