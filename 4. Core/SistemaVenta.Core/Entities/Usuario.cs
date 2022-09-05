using System;
using System.Collections.Generic;

namespace SistemaVenta.Core.Entities
{
    public partial class Usuario : BaseEntity
    {
        public string Cuenta { get; set; }
        public string Contrasena { get; set; }
        public string NombreUsuario { get; set; }
        public int IdRol { get; set; }
    }
}
