using Backend.PayFlow.DOMAIN.Core.DTOs;

namespace Backend.PayFlow.DOMAIN.Core.Interfaces
{
    public interface IHistorialSesionesRepository
    {
        Task<IEnumerable<HistorialSesionesDTO>> BuscarHistSesionPorTipAsc(string TipAcceso);
        Task<IEnumerable<HistorialSesionesDTO>> ListarHistSesion();
        Task<bool> RegistrarHistSesion(HistorialSesionesCreateDTO dto);
    }
}