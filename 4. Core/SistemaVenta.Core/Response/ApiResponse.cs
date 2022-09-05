using SistemaVenta.Core.CustionEntities;
using System.Collections.Generic;

namespace SistemaVenta.Core.Response
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
            CodigoHTTP = 200;
            ResultadoIndicador = 1;
            ResultadoDescripcion = "OK";
        }
        public int CodigoHTTP { get; set; }
        public int ResultadoIndicador { get; set; }
        public string ResultadoDescripcion {get; set; }
        public MetaData Meta { get; set; }
        public T Data { get; set; }
        public List<string> Error { get; set; }


    }
}
