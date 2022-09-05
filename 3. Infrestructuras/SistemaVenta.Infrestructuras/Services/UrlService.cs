
using AplicacionPersonal.Infraestructura.Interfaces;
using SistemaVenta.Core.QueryFilters;
using System;

namespace AplicacionPersonal.Infraestructura.Services
{
    public class UrlService:IUrlService
    {
        private readonly string _baseUri;
        public UrlService(string baseUri)
        {
            _baseUri = baseUri;
        }
        public Uri PaginationUri(ProductoQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }
    }
}
