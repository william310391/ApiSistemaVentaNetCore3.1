using SistemaVenta.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVenta.Core.Entities
{
    public class Seguridad: BaseEntity
    {
        public string Usuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public RoleType Rol { get; set; }
    }
}
