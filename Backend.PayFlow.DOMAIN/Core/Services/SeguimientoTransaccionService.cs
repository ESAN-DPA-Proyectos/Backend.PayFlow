using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.PayFlow.DOMAIN.Core.Services
{
    public class SeguimientoTransaccionService : ISeguimientoTransaccionService
    {
        private readonly ISeguimientoTransaccionRepository _seguimientoTransaccionRepository;
        public SeguimientoTransaccionService(ISeguimientoTransaccionRepository seguimientoTransaccionRepository)
        {
            _seguimientoTransaccionRepository = seguimientoTransaccionRepository;
        }


        public async Task<IEnumerable<SeguimientoTransaccion>> ObtenerTodosSeguimientoTransaccionesAsync()
        {
            return await _seguimientoTransaccionRepository.ObtenerTodosSeguimientoTransaccionesAsync();
        }
        public async Task<SeguimientoTransaccion?> ObtenerSeguimientoTransaccionPorIdAsync(int id)
        {
            return await _seguimientoTransaccionRepository.ObtenerSeguimientoTransaccionPorIdAsync(id);
        }
        public async Task<SeguimientoTransaccion> AgregarSeguimientoTransaccionAsync(SeguimientoTransaccion seguimientoTransaccion)
        {
            return await _seguimientoTransaccionRepository.AgregarSeguimientoTransaccionAsync(seguimientoTransaccion);
        }
        public async Task<SeguimientoTransaccion?> ActualizarSeguimientoTransaccionAsync(SeguimientoTransaccion seguimientoTransaccion)
        {
            return await _seguimientoTransaccionRepository.ActualizarSeguimientoTransaccionAsync(seguimientoTransaccion);
        }
        public async Task<bool> EliminarSeguimientoTransaccionAsync(int id)
        {
            return await _seguimientoTransaccionRepository.EliminarSeguimientoTransaccionAsync(id);
        }
    }
}
