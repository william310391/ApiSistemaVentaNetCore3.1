using SistemaVenta.Core.CustionEntities;
using SistemaVenta.Core.DTOs;
using SistemaVenta.Core.Entities;
using SistemaVenta.Core.QueryFilters;
using SistemaVenta.Core.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaVenta.Negocio.Interfaces
{
    public interface IProductoService
    {
        IEnumerable<Producto> GetProductos();
        Task<ApiResponse<IEnumerable<ProductoDTO>>> GetProductosByFilters(ProductoQueryFilter filters);
        Task<ApiResponse<ProductoDTO>> GetProducto(int id);
        Task<ApiResponse<ProductoDTO>> InsertProducto(ProductoDTO productoDTO);
        Task<ApiResponse<bool>> UpdateProducto(ProductoDTO productoDTO);
        Task<ApiResponse<bool>> DeleteProducto(int id);
    }
}