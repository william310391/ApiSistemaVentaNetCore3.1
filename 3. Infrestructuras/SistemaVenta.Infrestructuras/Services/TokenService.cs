using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SistemaVenta.Core.DTOs;
using SistemaVenta.Infraestructura.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SistemaVenta.Infraestructura.Services
{

    public class TokenService :ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly string _Issuer;
        private readonly string _Audience;
        private readonly string _SecretKey;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            _Issuer = _configuration["Authentication:Issuer"].ToString();
            _Audience = _configuration["Authentication:Audience"].ToString();
            _SecretKey = _configuration["Authentication:SecretKey"].ToString();
        }
        public string GenerarToken(SeguridadDTO seguridadDTO)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_SecretKey));

            var SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(SigningCredentials);

            //claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,seguridadDTO.NombreUsuario),
                new Claim("Usuario", seguridadDTO.Usuario),
                new Claim(ClaimTypes.Role, seguridadDTO.Rol.ToString()),

            };
            //Payload
            var payload = new JwtPayload
            (
                _Issuer,
                _Audience,
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(2)
            );

            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
