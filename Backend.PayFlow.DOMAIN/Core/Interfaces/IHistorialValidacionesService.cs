using Backend.PayFlow.DOMAIN.Core.Entities;

namespace Backend.PayFlow.DOMAIN.Core.Interfaces
{
    public interface IHistorialValidacionesService
    {
        bool AddValidation(HistorialValidaciones validation);
        bool DeleteValidation(int id);
        Task<List<HistorialValidaciones>> GetAllValidationsAsync();
        Task<HistorialValidaciones> GetValidationByIdAsync(int id);
        bool UpdateValidation(HistorialValidaciones validation);
    }
}