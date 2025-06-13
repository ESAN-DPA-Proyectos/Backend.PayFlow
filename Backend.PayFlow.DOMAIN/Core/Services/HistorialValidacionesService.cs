using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Backend.PayFlow.DOMAIN.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.PayFlow.DOMAIN.Core.Services
{
    public class HistorialValidacionesService : IHistorialValidacionesService
    {
        private readonly IHistorialValidacionesRepository _historialValidacionesRepository;

        public HistorialValidacionesService(IHistorialValidacionesRepository historialValidacionesRepository)
        {
            _historialValidacionesRepository = historialValidacionesRepository;
        }

        public async Task<List<HistorialValidaciones>> GetAllValidationsAsync()
        {
            return await _historialValidacionesRepository.GetAllValidationsAsync();
        }
        public async Task<HistorialValidaciones> GetValidationByIdAsync(int id)
        {
            return await _historialValidacionesRepository.GetValidationByIdAsync(id);
        }
        public bool AddValidation(HistorialValidaciones validation)
        {
            if (validation == null)
                throw new ArgumentNullException(nameof(validation));
            _historialValidacionesRepository.AddValidationAsync(validation).Wait();
            return true;
        }
        public bool UpdateValidation(HistorialValidaciones validation)
        {
            if (validation == null)
                throw new ArgumentNullException(nameof(validation));
            _historialValidacionesRepository.UpdateValidationAsync(validation).Wait();
            return true;
        }
        public bool DeleteValidation(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Invalid ID", nameof(id));
            _historialValidacionesRepository.DeleteValidationAsync(id).Wait();
            return true;
        }
    }
}
