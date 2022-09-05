using SistemaVenta.Core.CustionEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVenta.Core.QueryFilters
{
    public class ProductoQueryFilter : PagedListBase
    {
        public int? idUsuario { get; set; }
        public DateTime? fecha { get; set; }
        public string descripcion { get; set; }
 

    }
}
