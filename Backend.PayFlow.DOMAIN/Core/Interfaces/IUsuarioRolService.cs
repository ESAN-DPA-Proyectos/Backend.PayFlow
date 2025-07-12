using Backend.PayFlow.DOMAIN.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.PayFlow.DOMAIN.Core.Interfaces
{
    public interface IUsuarioRolService
    {
        Task<bool> AsignarRolAsync(UsuarioRolDto dto);
    }
}
