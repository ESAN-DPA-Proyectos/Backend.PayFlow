using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.PayFlow.DOMAIN.Core.Services
{
    public class UsuarioRolService : IUsuarioRolService
    {
        private readonly IUsuarioRolRepository _repo;

        public UsuarioRolService(IUsuarioRolRepository repo)
        {
            _repo = repo;
        }

        public Task<bool> AsignarRolAsync(UsuarioRolDto dto)
        {
            return _repo.AsignarAsync(dto.IdUsuario, dto.IdRol);
        }
    }
}
