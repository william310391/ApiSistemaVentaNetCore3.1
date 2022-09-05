using SistemaVenta.Core.DTOs;
using SistemaVenta.Core.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.Negocio.Interfaces
{
    public interface IUsuarioService
    {
        Task<ApiResponse<UsuarioDTO>> GetLoginByCredentials(UsuarioDTO usuarioDTO);
        Task<ApiResponse<UsuarioDTO>> RegistrarUsuario(UsuarioDTO usuarioDTO);

    }
}
