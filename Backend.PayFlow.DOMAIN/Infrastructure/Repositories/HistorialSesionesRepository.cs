using Backend.PayFlow.DOMAIN.Core.DTOs;
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
    public class HistorialSesionesRepository : IHistorialSesionesRepository
    {
        private readonly PayFlowDbContext _context;

        public HistorialSesionesRepository(PayFlowDbContext context)
        {
            _context = context;
        }

        /* Insert */
        public async Task<bool> RegistrarHistSesion(HistorialSesionesCreateDTO dto)
        {
            var hs = new HistorialSesiones
            {
                IdUsuario = dto.IdUsuario,
                FechaHora = dto.FechaHora,
                TipoAcceso = dto.TipoAcceso,
                DireccionIp = dto.DireccionIP,
            };

            _context.HistorialSesiones.Add(hs);
            await _context.SaveChangesAsync();
            return true;
        }

        /* Select */
        public async Task<IEnumerable<HistorialSesionesDTO>> ListarHistSesion()
        {
            return await _context.HistorialSesiones.Select(hs => new HistorialSesionesDTO
            {
                IdSesion = hs.IdSesion,
                IdUsuario = (int)hs.IdUsuario,
                FechaHora = (DateTime)hs.FechaHora,
                TipoAcceso = hs.TipoAcceso,
                DireccionIP = hs.DireccionIp,
            }
                ).ToListAsync();
        }

        /* Select */
        public async Task<IEnumerable<HistorialSesionesDTO>> BuscarHistSesionPorTipAsc(string TipAcceso)
        {
            /* Solo busca el priemro */
            //var hs = await _context.HistorialSesiones.FirstOrDefaultAsync(r => r.TipoAcceso == TipAcceso);

            /* busca todos */
            return await _context.HistorialSesiones.Select(hs => new HistorialSesionesDTO
            {
                IdSesion = hs.IdSesion,
                IdUsuario = (int)hs.IdUsuario,
                FechaHora = (DateTime)hs.FechaHora,
                TipoAcceso = hs.TipoAcceso,
                DireccionIP = hs.DireccionIp,
            }
                ).Where(r => r.TipoAcceso.Contains(TipAcceso)).ToListAsync();


        }
    }
}
