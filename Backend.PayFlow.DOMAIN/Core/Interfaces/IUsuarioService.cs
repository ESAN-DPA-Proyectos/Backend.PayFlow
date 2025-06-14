﻿using Backend.PayFlow.DOMAIN.Core.DTOs;
using System.Threading.Tasks;

namespace Backend.PayFlow.DOMAIN.Core.Interfaces
{
    public interface IUsuarioService
    {
        Task<bool> RegistrarUsuarioAsync(UsuarioRegisterDto usuarioDto);

        Task<UsuarioDto?> ObtenerUsuarioPorIdAsync(int id);

        Task<IEnumerable<UsuarioDto>> ObtenerTodosLosUsuariosAsync();

        Task<bool> CambiarContrasenaAsync(int idUsuario, string nuevaContrasena);


    }
}
