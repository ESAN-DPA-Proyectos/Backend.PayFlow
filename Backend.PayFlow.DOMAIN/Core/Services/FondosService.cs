using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.PayFlow.DOMAIN.Core.Services
{
    public class FondosService : IFondosService
    {
        private readonly IFondosRepository _fondosRepository;
        public FondosService(IFondosRepository fondosRepository)
        {
            _fondosRepository = fondosRepository;
        }

        public async Task<IEnumerable<FondosListDTO>> GetAllfunds()
        {
            var funds = await _fondosRepository.GetAllFunds();
            var fundsDTO = funds.Select(f => new FondosListDTO
            {
                IdFondo = f.IdFondo,
                Nombre = f.Nombre,
                Descripcion = f.Descripcion,
                AportePorAsociado = f.AportePorAsociado,
                Meta = f.Meta,
                SaldoActual = f.SaldoActual,
                Estado = f.Estado
            });
            return fundsDTO;
        }

        public async Task<FondosDTO?> GetFondosById(int id)
        {
            var fondos = await _fondosRepository.GetFondosById(id);
            if (fondos == null)
            {
                return null;
            }
            var fondosDTO = new FondosDTO

            {
                IdFondo = fondos.IdFondo,
                Nombre = fondos.Nombre,
                Descripcion = fondos.Descripcion,
                Meta = fondos.Meta,
                SaldoActual = fondos.SaldoActual,
                Estado = fondos.Estado
            };
            return fondosDTO;
        }

        public async Task<int> AddFondos(FondosCreateDTO fondosCreateDTO)
        {
            var fondos = new Fondos
            {
                Nombre = fondosCreateDTO.Nombre,
                Descripcion = fondosCreateDTO.Descripcion,
                AportePorAsociado = fondosCreateDTO.AportePorAsociado,
                Meta = fondosCreateDTO.Meta,
                SaldoActual = fondosCreateDTO.SaldoActual,
                Estado = fondosCreateDTO.Estado
            };
            return await _fondosRepository.AddFondos(fondos);
        }

        // Update Fondos
        public async Task<bool> UpdateFondos(FondosDTO fondosDTO)
        {
            var fondos = new Fondos
            {
                IdFondo = fondosDTO.IdFondo,
                Nombre = fondosDTO.Nombre,
                Descripcion = fondosDTO.Descripcion,
                Meta = fondosDTO.Meta,
                SaldoActual = fondosDTO.SaldoActual,
                Estado = fondosDTO.Estado
            };
            return await _fondosRepository.UpdateFondos(fondos);
        }

        // Delete Fondos
        public async Task<bool> DeleteFondos(int id)
        {
            var fondos = await _fondosRepository.GetFondosById(id);
            if (fondos == null)
            {
                return false;
            }
            return await _fondosRepository.DeleteFondos(id);
        }
    }
}
