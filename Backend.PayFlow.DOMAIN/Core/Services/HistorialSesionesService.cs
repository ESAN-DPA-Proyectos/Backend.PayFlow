using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Backend.PayFlow.DOMAIN.Infrastructure.Data;
using Backend.PayFlow.DOMAIN.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Backend.PayFlow.DOMAIN.Core.Services
{
    public class HistorialSesionesService : IHistorialSesionesService
    {
        private readonly IHistorialSesionesRepository _historialSesionesRepository;

        public HistorialSesionesService(IHistorialSesionesRepository historialSesionesRepository)
        {
            _historialSesionesRepository = historialSesionesRepository;
        }

        public async Task<IEnumerable<HistorialSesionesDTO>> BuscarHistSesionPorTipAsc(string TipAcceso)
        {
            return await _historialSesionesRepository.BuscarHistSesionPorTipAsc(TipAcceso);
        }

        public async Task<IEnumerable<HistorialSesionesDTO>> ListarHistSesion()
        {
            return await _historialSesionesRepository.ListarHistSesion();
        }

        public async Task<bool> RegistrarHistSesion(HistorialSesionesCreateDTO dto)
        {
            return await _historialSesionesRepository.RegistrarHistSesion(dto);
        }

    }
}
