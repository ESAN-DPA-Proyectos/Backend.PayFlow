using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Backend.PayFlow.DOMAIN.Infrastructure.Data;
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

        // Get all validation history records
        public List<HistorialValidaciones> GetAll()
        {
            return _context.HistorialValidaciones.ToList();
        }

        // Get a validation history record by ID
        public HistorialValidaciones GetById(int id)
        {
            return _context.HistorialValidaciones.FirstOrDefault(h => h.IdHistorial == id);
        }

        // Add a new validation history record
        public void Add(HistorialValidaciones historialValidacion)
        {
            _context.HistorialValidaciones.Add(historialValidacion);
            _context.SaveChanges();
        }


        // Update an existing validation history record
        public void Update(HistorialValidaciones historialValidacion)
        {
            var entidadExistente = _context.HistorialValidaciones
                .FirstOrDefault(h => h.IdHistorial == historialValidacion.IdHistorial);

            if (entidadExistente != null)
            {
                // Actualiza campo por campo
                entidadExistente.IdTransaccion = historialValidacion.IdTransaccion;
                entidadExistente.TipoValidacion = historialValidacion.TipoValidacion;
                entidadExistente.Resultado = historialValidacion.Resultado;
                entidadExistente.Observacion = historialValidacion.Observacion;
                entidadExistente.FechaValidacion = historialValidacion.FechaValidacion;
                entidadExistente.ValidadoPor = historialValidacion.ValidadoPor;

                _context.SaveChanges();
            }
        }

        // Delete a validation history record
        public void Delete(int id)
        {
            var historialValidacion = _context.HistorialValidaciones.FirstOrDefault(h => h.IdHistorial == id);
            if (historialValidacion != null)
            {
                _context.HistorialValidaciones.Remove(historialValidacion);
                _context.SaveChanges();
            }
        }

    }
}
