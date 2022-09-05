using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVenta.Core.CustionEntities
{
    public class PagedListBase
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string Url { get; set; }
    }
}
