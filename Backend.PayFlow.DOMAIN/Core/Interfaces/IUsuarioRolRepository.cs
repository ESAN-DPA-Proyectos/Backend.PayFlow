using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.PayFlow.DOMAIN.Core.Interfaces
{
    public interface IUsuarioRolRepository
    {
        Task<bool> AsignarAsync(int idUsuario, int idRol);
    }
}