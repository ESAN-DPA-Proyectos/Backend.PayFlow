using Backend.PayFlow.DOMAIN.Core.Entities;

namespace Backend.PayFlow.DOMAIN.Core.Interfaces
{
    public interface IHistorialValidacionesRepository
    {
        Task AddValidationAsync(HistorialValidaciones validation);
        Task DeleteValidationAsync(int id);
        Task<List<HistorialValidaciones>> GetAllValidationsAsync();
        Task<HistorialValidaciones> GetValidationByIdAsync(int id);
        Task UpdateValidationAsync(HistorialValidaciones validation);
    }
}