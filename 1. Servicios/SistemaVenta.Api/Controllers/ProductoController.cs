using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaVenta.Core.DTOs;
using SistemaVenta.Core.QueryFilters;
using SistemaVenta.Core.Response;
using SistemaVenta.Negocio.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SistemaVenta.Api.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ProducesErrorResponseType(typeof(ApiResponse<List<string>>))]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public ProductoController(IUnitOfWorkService unitOfWorkService)
        {  
            _unitOfWorkService = unitOfWorkService;
        }
        /// <summary>
        /// Devuelve todos los productos
        /// </summary>
        /// <param name="filter">datos para los filtros y paginacion</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet(Name = nameof(GetProductos))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<ProductoDTO>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetProductos([FromQuery] ProductoQueryFilter filter)
        {           
            filter.Url = Url.RouteUrl(nameof(GetProductos));
            var response= await _unitOfWorkService.ProductoService.GetProductosByFilters(filter);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(response.Meta));
            return Ok(response);            
        }
        /// <summary>
        /// Busqueda de Producto por id
        /// </summary>
        /// <param name="id">Id de producto</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<ProductoDTO>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetProducto(int id)
        {
            var response = await _unitOfWorkService.ProductoService.GetProducto(id);
            return Ok(response);
        }
        /// <summary>
        /// Registro del Producto
        /// </summary>
        /// <param name="productoDTO">Datos del Producto</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<ProductoDTO>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> InsertProducto([CustomizeValidator(RuleSet = "RegistarProducto")] ProductoDTO productoDTO)
        {    
            var response = await _unitOfWorkService.ProductoService.InsertProducto(productoDTO);
            return Ok(response);
        }
        /// <summary>
        /// Actualizar Producto
        /// </summary>
        /// <param name="productoDTO">Datos del Productos</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<bool>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateProducto([CustomizeValidator(RuleSet = "RegistarProducto")] ProductoDTO productoDTO)
        {
            var response = await _unitOfWorkService.ProductoService.UpdateProducto(productoDTO);
            return Ok(response);
        }
        /// <summary>
        /// Eliminar Producto
        /// </summary>
        /// <param name="id">Id del Procuto</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<bool>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteProducto(int id)
        {           
            var response = await _unitOfWorkService.ProductoService.DeleteProducto(id);
            return Ok(response);
        }

    }
}
