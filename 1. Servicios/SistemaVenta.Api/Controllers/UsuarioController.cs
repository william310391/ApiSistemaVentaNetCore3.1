using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVenta.Core.DTOs;
using SistemaVenta.Core.Response;
using SistemaVenta.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SistemaVenta.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ProducesErrorResponseType(typeof(ApiResponse<List<string>>))]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;
        public UsuarioController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }
        /// <summary>
        /// Valida usuario y contraseña de usuario para acceder al sistema
        /// </summary>
        /// <param name="usuarioDTO">Ingresar cuenta y contraseña del usuario</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<UsuarioDTO>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GetLoginByCredentials([CustomizeValidator(RuleSet = "Login")]UsuarioDTO usuarioDTO)
        {
            var response = await _unitOfWorkService.UsuarioService.GetLoginByCredentials(usuarioDTO);
            return StatusCode(response.CodigoHTTP, response);
        }
        /// <summary>
        /// registro del usuario de sistema
        /// </summary>
        /// <param name="usuarioDTO">Datos de registro del usuario</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<UsuarioDTO>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> RegistrarUsuario(UsuarioDTO usuarioDTO)
        {
            var response = await _unitOfWorkService.UsuarioService.RegistrarUsuario(usuarioDTO);
            return StatusCode(response.CodigoHTTP, response);
        }



    }
}
