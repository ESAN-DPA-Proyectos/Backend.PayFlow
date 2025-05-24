using Backend.PayFlow.DOMAIN.Core.Entities;

namespace Backend.PayFlow.DOMAIN.Infrastructure.Repositories
{
    public interface ITransaccionesRepository
    {
        Task<int> AddTransacciones(Transacciones transacciones);
        Task<IEnumerable<Transacciones>> GetAllTransactions();
        Task<Transacciones?> GetTransaccionesById(int id);
        Task<bool> UpdateTransacciones(Transacciones transacciones);
    }
}