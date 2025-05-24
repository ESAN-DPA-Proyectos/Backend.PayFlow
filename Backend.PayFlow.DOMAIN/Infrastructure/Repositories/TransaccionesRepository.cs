using Backend.PayFlow.DOMAIN.Core.Entities;
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

        // Add transacción

        public async Task<int> AddTransacciones(Transacciones transacciones)
        {
            await _context.Transacciones.AddAsync(transacciones);
            await _context.SaveChangesAsync();
            return transacciones.IdTransaccion;

        }

        // Update transacción
        public async Task<bool> UpdateTransacciones(Transacciones transacciones)
        {
            var existingTransacciones = await _context.Transacciones.FindAsync(transacciones.IdTransaccion);
            if (existingTransacciones == null)
            {
                return false;
            }
            existingTransacciones.Tipo = transacciones.Tipo;
            existingTransacciones.Monto = transacciones.Monto;
            existingTransacciones.FechaRegistro = transacciones.FechaRegistro;
            existingTransacciones.Estado = transacciones.Estado;
            existingTransacciones.MetodoPago = transacciones.MetodoPago;
            _context.Transacciones.Update(existingTransacciones);
            await _context.SaveChangesAsync();
            return true;
        }

        //Delete transacción





    }

}


