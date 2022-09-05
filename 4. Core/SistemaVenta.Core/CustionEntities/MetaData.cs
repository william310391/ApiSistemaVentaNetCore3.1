using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVenta.Core.CustionEntities
{
    public class MetaData
    {
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalCount { get; set; }
        public bool HasPreviusPage { get; set; }
        public bool HasNextPage { get; set; }
        public int NextPageNumber { get; set; }
        public int PreviusPageNumber { get; set; }
        public string NextPageUrl { get; set; }
        public string PreviusPageUrl { get; set; }

    }
}
