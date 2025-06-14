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
    }
}
