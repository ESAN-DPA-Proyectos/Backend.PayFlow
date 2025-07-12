using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Entities;

namespace Backend.PayFlow.DOMAIN.Core.Interfaces
{
    public interface ITransaccionesRepository
    {
        Task<int> AddTransacciones(Transacciones transacciones);
        Task<IEnumerable<Transacciones>> GetAllTransactions();
        Task<Transacciones?> GetTransaccionesById(int id);
        Task<bool> UpdateTransacciones(Transacciones transacciones);
        Task<IEnumerable<TransaccionesDTO>> GetTransaccionesByUsu(int id);
    }
}