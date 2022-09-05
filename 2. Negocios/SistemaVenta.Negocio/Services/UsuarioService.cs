using SistemaVenta.Core.DTOs;
using SistemaVenta.Core.Entities;
using SistemaVenta.Core.Exceptions;
using SistemaVenta.Core.Response;
using SistemaVenta.Infraestructura.Interfaces;
using SistemaVenta.Negocio.Interfaces;
using System.Threading.Tasks;

namespace SistemaVenta.Negocio.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<UsuarioDTO>> GetLoginByCredentials(UsuarioDTO usuarioDTO)
        {
            var response = new ApiResponse<UsuarioDTO>(new UsuarioDTO());
            var ent = await _unitOfWork.UsuarioRepository.GetLoginByCredentials(usuarioDTO);
            if (ent != null)
            {
                var dto = _unitOfWork.Mapper.Map<UsuarioDTO>(ent);
                if (_unitOfWork.PasswordService.check(dto.Contrasena, usuarioDTO.Contrasena))
                {
                    usuarioDTO = dto;
                    response = new ApiResponse<UsuarioDTO>(usuarioDTO);
                }
                else
                {
                    //throw new BusinessException("El usuario o contraseña ingresados son son incorrectas");
                    response.ResultadoDescripcion = "La contraseña ingresado es incorrecta";
                    response.ResultadoIndicador = 0;
                    response.CodigoHTTP = 401;
                }
            }
            else
            {
                response.ResultadoDescripcion = "El usuario ingresado es incorrecto";
                response.ResultadoIndicador = 0;
                response.CodigoHTTP = 400;
            }
            return response;
        }

        public async Task<ApiResponse<UsuarioDTO>> RegistrarUsuario(UsuarioDTO usuarioDTO)
        {
            usuarioDTO.Contrasena = _unitOfWork.PasswordService.Hash(usuarioDTO.Contrasena);
            var ent = _unitOfWork.Mapper.Map<Usuario>(usuarioDTO);
            await _unitOfWork.UsuarioRepository.Add(ent);
            await _unitOfWork.SaveChangesAsync();
            usuarioDTO = _unitOfWork.Mapper.Map<UsuarioDTO>(ent);
            var response = new ApiResponse<UsuarioDTO>(usuarioDTO);
            return response;
        }


    }
}
