using Microsoft.EntityFrameworkCore;
using SistemaVenta.Infraestructura.Data;
using SistemaVenta.Core.Entities;
using SistemaVenta.Infraestructura.Interfaces;
using SistemaVenta.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.Infraestructura.Repositories
{
    public class ProductoRepository : BaseRepository<Producto>, IProductoRepository
    {     
        public ProductoRepository(VentasContext context):base(context) { }

        public async Task<IEnumerable<Producto>> GetProductoByUsuario(int userID)
        {
            return await _entities.Where(x => x.IdUsuarioRegistro == userID).ToArrayAsync();
        }

        public async Task<IEnumerable<Producto>> GetProductosByFilters(ProductoQueryFilter Filters)
        {
          var aa= await _entities.AsQueryable()
                .Where(x => x.IdUsuarioRegistro == (Filters.idUsuario != null ? (int)Filters.idUsuario : x.IdUsuarioRegistro))
                .Where(x => x.FechaRegistro.Date ==(Filters.fecha != null ? ((DateTime)Filters.fecha).Date: x.FechaRegistro.Date))
                .Where(x => x.Descripcion.ToLower().Contains((Filters.descripcion != null ? Filters.descripcion.ToLower() : x.Descripcion.ToLower())))
                .ToListAsync();

            return aa;
        }
    }
}
