using SistemaVenta.Core.DTOs;
using SistemaVenta.Core.Entities;
using SistemaVenta.Infraestructura.Interfaces;
using System.Threading.Tasks;

namespace SistemaVenta.Infrestructuras.Interfaces
{
    public interface ISeguridadRepository:IBaseRepository<Seguridad>
    {
        Task<Seguridad> GetLoginByCredentials(SeguridadDTO seguridadDTO);
    }
}