using SistemaVenta.Core.QueryFilters;
using System;

namespace AplicacionPersonal.Infraestructura.Interfaces
{
    public interface IUrlService
    {
        Uri PaginationUri(ProductoQueryFilter filter, string actionUrl);
    }
}
