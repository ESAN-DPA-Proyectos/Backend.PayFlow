using Backend.PayFlow.DOMAIN.Core.DTOs;
using Backend.PayFlow.DOMAIN.Core.Entities;
using Backend.PayFlow.DOMAIN.Core.Interfaces;
using Backend.PayFlow.DOMAIN.Infrastructure.Data;
using Backend.PayFlow.DOMAIN.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.PayFlow.DOMAIN.Core.Services
{
    public class RolesService : IRolesService
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesService(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        public async Task<bool> ActualizarRol(Roles rol)
        {
            return await _rolesRepository.ActualizarRol(rol);
        }

        public async Task<Roles> BuscarRolPorId(int id)
        {
            return await _rolesRepository.BuscarRolPorId(id);
        }

        public async Task<bool> DeleteRol(int id)
        {
            return await _rolesRepository.DeleteRol(id);
        }

        public async Task<IEnumerable<RolesDTO>> ListarRoles()
        {
            return await _rolesRepository.ListarRoles();
        }

        public async Task<bool> RegistrarRol(RolesCreateDTO dto)
        {
            return await _rolesRepository.RegistrarRol(dto);
        }

        public async Task<bool> RemoveRol(int id)
        {
            return await _rolesRepository.RemoveRol(id);
        }

    }
}
