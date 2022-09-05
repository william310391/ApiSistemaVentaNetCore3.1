using SistemaVenta.Core.DTOs;
using SistemaVenta.Core.Response;
using System.Threading.Tasks;

namespace SistemaVenta.Negocio.Interfaces
{
    public interface ISeguridadService
    {
        Task<ApiResponse<SeguridadDTO>> RegistrarUsuarioApi(SeguridadDTO seguridadDTO);
        Task<ApiResponse<SeguridadDTO>> AuthenticationApi(SeguridadDTO seguridadDTO);
   
    }
}