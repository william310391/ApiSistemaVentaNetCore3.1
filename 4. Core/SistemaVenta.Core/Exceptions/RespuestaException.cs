using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVenta.Core.Exceptions
{
    public class RespuestaException : Exception
    {
        public RespuestaException()
        {
            
        }
        public RespuestaException(string message) : base(message)
        {

        }
    }
  

}
