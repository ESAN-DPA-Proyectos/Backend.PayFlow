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
    public class SeguimientoTransaccionRepository : ISeguimientoTransaccionRepository
    {
        private readonly PayFlowDbContext _context;
        public SeguimientoTransaccionRepository(PayFlowDbContext context)
        {
            _context = context;
        }


        //Get all transactions tracking records
        public async Task<IEnumerable<SeguimientoTransaccion>> ObtenerTodosSeguimientoTransaccionesAsync()
        {
            return await _context.SeguimientoTransaccion.ToListAsync();
        }
        //Get transaction tracking record by ID
        public async Task<SeguimientoTransaccion?> ObtenerSeguimientoTransaccionPorIdAsync(int id)
        {
            return await _context.SeguimientoTransaccion.FindAsync(id);
        }
        //Add a new transaction tracking record
        public async Task<SeguimientoTransaccion> AgregarSeguimientoTransaccionAsync(SeguimientoTransaccion seguimientoTransaccion)
        {
            _context.SeguimientoTransaccion.Add(seguimientoTransaccion);
            await _context.SaveChangesAsync();
            return seguimientoTransaccion;
        }
        //Update an existing transaction tracking record
        public async Task<SeguimientoTransaccion?> ActualizarSeguimientoTransaccionAsync(SeguimientoTransaccion seguimientoTransaccion)
        {
            var existing = await _context.SeguimientoTransaccion.FindAsync(seguimientoTransaccion.IdSeguimiento);
            if (existing == null) return null;
            existing.IdTransaccion = seguimientoTransaccion.IdTransaccion;
            existing.Hito = seguimientoTransaccion.Hito;
            existing.FechaHora = seguimientoTransaccion.FechaHora;
            existing.Estado = seguimientoTransaccion.Estado;
            _context.SeguimientoTransaccion.Update(existing);
            await _context.SaveChangesAsync();
            return existing;
        }
        //Delete a transaction tracking record
        public async Task<bool> EliminarSeguimientoTransaccionAsync(int id)
        {
            var existing = await _context.SeguimientoTransaccion.FindAsync(id);
            if (existing == null) return false;
            _context.SeguimientoTransaccion.Remove(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
