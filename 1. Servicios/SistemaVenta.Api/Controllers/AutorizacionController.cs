using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVenta.Core.DTOs;
using SistemaVenta.Core.Enumerations;
using SistemaVenta.Core.Response;
using SistemaVenta.Negocio.Interfaces;

namespace SistemaVenta.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ProducesErrorResponseType(typeof(ApiResponse<List<string>>))]
    [ApiController]
    public class AutorizacionController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        public AutorizacionController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }
        /// <summary>
        /// Valida usuario y contraseña para obtener Token
        /// </summary>
        /// <param name="seguridadDTO">ingresar cuenta y contraña</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<SeguridadDTO>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> Token(SeguridadDTO seguridadDTO)
        {           
            var response = await _unitOfWorkService.SeguridadService.AuthenticationApi(seguridadDTO);
            return StatusCode(response.CodigoHTTP, response);      
            //if (reponse.CodigoHTTP == (int)HttpStatusCode.OK)
            //{
            //    return Ok(reponse);
            //}
            //else {
            //    return Unauthorized(reponse);
            //}
        }
        /// <summary>
        /// Registro de Usuario para el uso del web api
        /// </summary>
        /// <param name="seguridadDTO">Datos del usuario</param>
        /// <returns></returns>        
        [HttpPost]
        [Authorize(Roles = nameof(RoleType.Administrador))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<SeguridadDTO>))]
        public async Task<IActionResult> RegistrarUsuarioApi(SeguridadDTO seguridadDTO)
        {
            var response = await _unitOfWorkService.SeguridadService.RegistrarUsuarioApi(seguridadDTO);
            return StatusCode(response.CodigoHTTP, response);
        }


    }
}
