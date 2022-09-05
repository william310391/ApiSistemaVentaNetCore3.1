using SistemaVenta.Core.Entities;
using SistemaVenta.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.Infraestructura.Interfaces
{
    public interface IProductoRepository:IBaseRepository<Producto>
    {
        Task<IEnumerable<Producto>> GetProductoByUsuario(int userID);
        Task<IEnumerable<Producto>> GetProductosByFilters(ProductoQueryFilter Filters);
    }
}
