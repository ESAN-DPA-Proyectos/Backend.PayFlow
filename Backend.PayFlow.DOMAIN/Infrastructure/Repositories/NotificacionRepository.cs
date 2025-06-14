using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Backend.PayFlow.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.PayFlow.DOMAIN.Infrastructure.Repositories
{
    public class NotificacionRepository : INotificacionRepository
    {
        private readonly PayFlowDbContext _context;

        public NotificacionRepository(PayFlowDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Notificacion notificacion)
        {
            _context.Notificaciones.Add(notificacion);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Notificacion>> GetAllAsync()
        {
            return await _context.Notificaciones
                .OrderByDescending(n => n.FechaCreacion)
                .ToListAsync();
        }

        public async Task<Notificacion?> GetByIdAsync(int id)
        {
            return await _context.Notificaciones.FindAsync(id);
        }
    }
}
