using SistemaVenta.Core.Entities;
using SistemaVenta.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVenta.Core.DTOs
{
    public class SeguridadDTO: BaseEntity
    {
        public string Usuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public RoleType Rol { get; set; }
        public string Token { get; set; }
    }
}
