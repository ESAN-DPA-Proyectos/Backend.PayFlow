using Backend.PayFlow.DOMAIN.Core.DTOs;

namespace Backend.PayFlow.DOMAIN.Core.Interfaces
{
    public interface IFondosService
    {
        Task<int> AddFondos(FondosCreateDTO fondosCreateDTO);
        Task<bool> DeleteFondos(int id);
        Task<IEnumerable<FondosListDTO>> GetAllfunds();
        Task<FondosDTO?> GetFondosById(int id);
        Task<bool> UpdateFondos(FondosDTO fondosDTO);
    }
}