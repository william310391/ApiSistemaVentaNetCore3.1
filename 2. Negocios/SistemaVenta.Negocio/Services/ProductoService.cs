using AplicacionPersonal.Infraestructura.Interfaces;
using SistemaVenta.Core.CustionEntities;
using SistemaVenta.Core.DTOs;
using SistemaVenta.Core.Entities;
using SistemaVenta.Core.Exceptions;
using SistemaVenta.Core.QueryFilters;
using SistemaVenta.Core.Response;
using SistemaVenta.Infraestructura.Interfaces;
using SistemaVenta.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVenta.Negocio.Services
{

    public class ProductoService : IProductoService
    { 
        private readonly IUnitOfWork _unitOfWork;    
        
        public ProductoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; 
        }  
        public IEnumerable<Producto> GetProductos()
        {
           return _unitOfWork.ProductoRepository.GetAll();           
        }
        public async Task<ApiResponse<IEnumerable<ProductoDTO>>> GetProductosByFilters(ProductoQueryFilter filters)
        {           
            filters.PageNumber = filters.PageNumber == 0 ? _unitOfWork.PaginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _unitOfWork.PaginationOptions.DefaultPageSize : filters.PageSize;

            var productos = await _unitOfWork.ProductoRepository.GetProductosByFilters(filters);
            var productosDTO = _unitOfWork.Mapper.Map<IEnumerable<ProductoDTO>>(productos);
            var pagedRes = PagedList<ProductoDTO>.Create(productosDTO, filters.PageNumber, filters.PageSize);
            var response = new ApiResponse<IEnumerable<ProductoDTO>>(productosDTO);

            var metaData = new MetaData
            {
                TotalCount = pagedRes.TotalCount,
                PageSize = pagedRes.PageSize,
                CurrentPage = pagedRes.CurrentPage,
                TotalPages = pagedRes.TotalPages,
                HasNextPage = pagedRes.HasNextPage,
                HasPreviusPage = pagedRes.HasPreviusPage,
                NextPageUrl = _unitOfWork.UrlService.PaginationUri(filters, filters.Url).ToString(),
                PreviusPageUrl = _unitOfWork.UrlService.PaginationUri(filters, filters.Url).ToString()
            };
            response.Meta = metaData;

           return response;
        }

        public async Task<ApiResponse<ProductoDTO>> GetProducto(int id)
        {
            var producto= await _unitOfWork.ProductoRepository.GetById(id);
            var productoDTO = _unitOfWork.Mapper.Map<ProductoDTO>(producto);
            var response = new ApiResponse<ProductoDTO>(productoDTO);
            return response;
        }

        public async Task<ApiResponse<ProductoDTO>> InsertProducto(ProductoDTO productoDTO)
        {

            var producto = _unitOfWork.Mapper.Map<Producto>(productoDTO);
            var usuario = await _unitOfWork.UsuarioRepository.GetById(producto.IdUsuarioRegistro);
            if (usuario == null)
            {
                throw new BusinessException("error");
            }
            var usuarioProducto = await _unitOfWork.ProductoRepository.GetProductoByUsuario(producto.IdUsuarioRegistro);
            if (usuarioProducto.Count() < 10)
            {
                var lastProducto = usuarioProducto.OrderByDescending(x => x.FechaRegistro).FirstOrDefault();
                if ((DateTime.Now - lastProducto.FechaRegistro).TotalDays < 7)
                {
                    throw new BusinessException("no puedes registrar el producto");
                }
            }
            await _unitOfWork.ProductoRepository.Add(producto);
            await _unitOfWork.SaveChangesAsync();
            productoDTO = _unitOfWork.Mapper.Map<ProductoDTO>(producto);
            var response = new ApiResponse<ProductoDTO>(productoDTO);
            return response;
        }

        public async Task<ApiResponse<bool>> UpdateProducto(ProductoDTO productoDTO)
        {
       
            var producto = await _unitOfWork.ProductoRepository.GetById(productoDTO.Id);
            producto.FechaModificacion = productoDTO.FechaModificacion;
            producto.IdUsuarioModificacion = productoDTO.IdUsuarioModificacion;
            producto.IndActivo = productoDTO.IndActivo;
            producto.NombreProducto= productoDTO.NombreProducto;
            producto.Descripcion = productoDTO.Descripcion;
            producto.Imagen = productoDTO.Imagen;
            _unitOfWork.ProductoRepository.Update(producto);
            await _unitOfWork.SaveChangesAsync();
            var response = new ApiResponse<bool>(true);
            return response;
        }
  
        public async Task<ApiResponse<bool>> DeleteProducto(int id)
        {
            await _unitOfWork.ProductoRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            var response = new ApiResponse<bool>(true);
            return response;
        }
    }
}
