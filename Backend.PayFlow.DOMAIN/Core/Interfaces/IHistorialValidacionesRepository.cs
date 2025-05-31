using Backend.PayFlow.DOMAIN.Core.Entities;

namespace Backend.PayFlow.DOMAIN.Core.Interfaces
{
    public interface IHistorialValidacionesRepository
    {
        void Add(HistorialValidaciones historialValidacion);
        void Delete(int id);
        List<HistorialValidaciones> GetAll();
        HistorialValidaciones GetById(int id);
        void Update(HistorialValidaciones historialValidacion);
    }
}