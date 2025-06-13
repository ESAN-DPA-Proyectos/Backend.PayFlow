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
    public class HistorialValidacionesRepository : IHistorialValidacionesRepository
    {
        public readonly PayFlowDbContext _context;
        public HistorialValidacionesRepository(PayFlowDbContext context)
        {
            _context = context;
        }

        //Get all validations
        public async Task<List<HistorialValidaciones>> GetAllValidationsAsync()
        {
            return await _context.HistorialValidaciones.ToListAsync();
        }
        // Get validation by ID
        public async Task<HistorialValidaciones> GetValidationByIdAsync(int id)
        {
            return await _context.HistorialValidaciones.FindAsync(id);
        }
        // Add a new validation
        public async Task AddValidationAsync(HistorialValidaciones validation)
        {
            _context.HistorialValidaciones.Add(validation);
            await _context.SaveChangesAsync();
        }
        // Update an existing validation
        public async Task UpdateValidationAsync(HistorialValidaciones validation)
        {
            _context.HistorialValidaciones.Update(validation);
            await _context.SaveChangesAsync();
        }
        // Delete a validation
        public async Task DeleteValidationAsync(int id)
        {
            var validation = await _context.HistorialValidaciones.FindAsync(id);
            if (validation != null)
            {
                _context.HistorialValidaciones.Remove(validation);
                await _context.SaveChangesAsync();
            }
        }

    }
}
