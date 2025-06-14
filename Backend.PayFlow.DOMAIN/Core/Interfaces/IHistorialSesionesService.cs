using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Entities;

namespace Backend.PayFlow.DOMAIN.Core.Interfaces
{
    public interface IHistorialSesionesService
    {
        Task<IEnumerable<HistorialSesionesDTO>> ListarHistSesion();
        Task<IEnumerable<HistorialSesionesDTO>> BuscarHistSesionPorTipAsc(string TipAcceso);
        Task<bool> RegistrarHistSesion(HistorialSesionesCreateDTO dto);
    }
}