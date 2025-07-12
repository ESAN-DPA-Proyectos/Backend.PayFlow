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

        public async Task<bool> CreateAsync(Notificacion notificacion)
        {
            _context.Notificaciones.Add(notificacion);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Notificacion>> GetAllAsync()
        {
            return await _context.Notificaciones
                .Include(n => n.IdUsuarioNavigation)
                .Include(n => n.IdTransaccionNavigation)
                .OrderByDescending(n => n.FechaCreacion)
                .ToListAsync();
        }

        public async Task<Notificacion?> GetByIdAsync(int id)
        {
            return await _context.Notificaciones
                .Include(n => n.IdUsuarioNavigation)
                .Include(n => n.IdTransaccionNavigation)
                .FirstOrDefaultAsync(n => n.IdNotificacion == id);
        }

        public async Task<bool> UpdateAsync(Notificacion notificacion)
        {
            _context.Notificaciones.Update(notificacion);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var noti = await _context.Notificaciones.FindAsync(id);
            if (noti == null) return false;

            _context.Notificaciones.Remove(noti);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
