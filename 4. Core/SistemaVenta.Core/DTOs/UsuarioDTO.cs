using SistemaVenta.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVenta.Core.DTOs
{
    public class UsuarioDTO: BaseEntity
    {
        public string Cuenta { get; set; }
        public string Contrasena { get; set; }
        public string NombreUsuario { get; set; }
        public int IdRol { get; set; }
    }
}

