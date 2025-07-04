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
    public class FondosRepository : IFondosRepository
    {
        private readonly PayFlowDbContext _context;
        public FondosRepository(PayFlowDbContext context)
        {
            _context = context;
        }

        // Get all fondos
        public async Task<IEnumerable<Fondos>> GetAllFondosAsync()
        {
            return await _context.Fondos.ToListAsync();
        }

        // Get fondos by id
        public async Task<Fondos?> GetFondosById(int id)
        {
            return await _context.Fondos.Where(f => f.IdFondo == id).FirstOrDefaultAsync();
        }

        // Add fondo
        public async Task<int> AddFondosAsync(Fondos fondos)
        {
            await _context.Fondos.AddAsync(fondos);
            await _context.SaveChangesAsync();
            return fondos.IdFondo;
        }

        // Update fondo
        public async Task<bool> UpdateFondos(Fondos fondos)
        {
            var existingFondos = await GetFondosById(fondos.IdFondo);
            if (existingFondos == null)
            {
                return false;
            }
            existingFondos.Nombre = fondos.Nombre;
            existingFondos.Descripcion = fondos.Descripcion;
            existingFondos.AportePorAsociado = fondos.AportePorAsociado;
            existingFondos.Meta = fondos.Meta;
            existingFondos.SaldoActual = fondos.SaldoActual;
            existingFondos.Estado = fondos.Estado;
            _context.Fondos.Update(existingFondos);
            await _context.SaveChangesAsync();
            return true;
        }

        // Delete fondo
        public async Task<bool> DeleteFondos(int id)
        {
            var fondos = await _context.Fondos.FindAsync(id);
            if (fondos == null)
            {
                return false;
            }
            _context.Fondos.Remove(fondos);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<IEnumerable<Fondos>> GetAllFunds()
        {
            throw new NotImplementedException();
        }

        public Task<int> AddFondos(Fondos fondos)
        {
            throw new NotImplementedException();
        }
    }
}
