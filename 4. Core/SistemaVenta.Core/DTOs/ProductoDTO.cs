using SistemaVenta.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistemaVenta.Core.DTOs
{
    public class ProductoDTO: BaseEntity
    {
      
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
    }
}
