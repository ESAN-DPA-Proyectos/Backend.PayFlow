using Backend.PayFlow.DOMAIN.Core.Entities;

namespace Backend.PayFlow.DOMAIN.Core.Interfaces
{
    public interface IFondosRepository
    {
        Task<int> AddFondos(Fondos fondos);
        Task<bool> DeleteFondos(int id);
        Task<IEnumerable<Fondos>> GetAllFunds();
        Task<Fondos?> GetFondosById(int id);
        Task<bool> UpdateFondos(Fondos fondos);
    }
}