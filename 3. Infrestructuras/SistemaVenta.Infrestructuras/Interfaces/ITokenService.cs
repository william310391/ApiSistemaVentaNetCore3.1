using SistemaVenta.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVenta.Infraestructura.Interfaces
{
    public interface ITokenService
    {
        string GenerarToken(SeguridadDTO seguridadDTO);
    }
}
