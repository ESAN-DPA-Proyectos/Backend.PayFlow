using Backend.PayFlow.DOMAIN.Core.DTOs;

namespace Backend.PayFlow.DOMAIN.Core.Interfaces
{
    public interface ITransaccionesService
    {
        Task<int> AddTransacciones(TransaccionesCreateDTO transaccionesDTO);
        Task<IEnumerable<TransaccionesListDTO>> GetAllTransactions();
        Task<TransaccionesListDTO> GetTransaccionesById(int id);
        Task<bool> UpdateTransacciones(TransaccionesListDTO transaccionesListDTO);
        Task<IEnumerable<TransaccionesDTO>> GetTransaccionesByUsu(int id);
    }
}