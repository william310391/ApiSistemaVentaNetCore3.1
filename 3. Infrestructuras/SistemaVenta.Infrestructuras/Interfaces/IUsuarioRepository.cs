using SistemaVenta.Core.DTOs;
using SistemaVenta.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaVenta.Infraestructura.Interfaces
{
    public interface IUsuarioRepository:IBaseRepository<Usuario>
    {
        Task<Usuario> GetLoginByCredentials(UsuarioDTO usuarioDTO);
    }
}