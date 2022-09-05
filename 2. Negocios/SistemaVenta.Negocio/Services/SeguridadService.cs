using SistemaVenta.Core.DTOs;
using SistemaVenta.Core.Entities;
using SistemaVenta.Core.Exceptions;
using SistemaVenta.Core.Response;
using SistemaVenta.Infraestructura.Interfaces;
using SistemaVenta.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVenta.Negocio.Services
{
    public class SeguridadService : ISeguridadService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SeguridadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<SeguridadDTO>> AuthenticationApi(SeguridadDTO seguridadDTO)
        {
            var response = new ApiResponse<SeguridadDTO>(new SeguridadDTO());
            var seguridad = await _unitOfWork.SeguridadRepository.GetLoginByCredentials(seguridadDTO);

            if (seguridad != null)
            {
                var dto = _unitOfWork.Mapper.Map<SeguridadDTO>(seguridad);
                if (_unitOfWork.PasswordService.check(dto.Contrasena, seguridadDTO.Contrasena))
                {
                    seguridadDTO = dto;
                    seguridadDTO.Token = _unitOfWork.TokenService.GenerarToken(seguridadDTO);
                    response = new ApiResponse<SeguridadDTO>(seguridadDTO);
                }
                else {
                    //throw new BusinessException("Las credenciales para el token son invalidas");
                    response.ResultadoDescripcion = "La contraseña ingresado es incorrecta";
                    response.ResultadoIndicador = 0;
                    response.CodigoHTTP = 401;
                }
            }
            else {
                //throw new BusinessException("Las credenciales para el token son invalidas");
                response.ResultadoDescripcion = "El usuario ingresado es incorrecto";
                response.ResultadoIndicador = 0;
                response.CodigoHTTP = 400;
            }  
            return response;
        }
        public async Task<ApiResponse<SeguridadDTO>> RegistrarUsuarioApi(SeguridadDTO seguridadDTO)
        {
            seguridadDTO.Contrasena = _unitOfWork.PasswordService.Hash(seguridadDTO.Contrasena);
            var seguridad = _unitOfWork.Mapper.Map<Seguridad>(seguridadDTO);
            await _unitOfWork.SeguridadRepository.Add(seguridad);
            await _unitOfWork.SaveChangesAsync();
            seguridadDTO= _unitOfWork.Mapper.Map<SeguridadDTO>(seguridad);
            var response = new ApiResponse<SeguridadDTO>(seguridadDTO);
            return response;
        }


    }
}
