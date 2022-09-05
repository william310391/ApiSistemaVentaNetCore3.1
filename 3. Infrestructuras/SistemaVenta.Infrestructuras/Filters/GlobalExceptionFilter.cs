using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SistemaVenta.Core.Response;
using SistemaVenta.Core.Exceptions;

using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SistemaVenta.Infraestructura.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(BusinessException))
            {
                var exception = (BusinessException)context.Exception;
                var response = new ApiResponse<List<string>>(new List<string>());
                List<string> errors = new List<string>();
                List<string> listaDefault = new List<string>();
                listaDefault = null;
                errors.Add(exception.Message);

                response.CodigoHTTP = (int)HttpStatusCode.BadRequest;
                response.ResultadoIndicador = 0;
                response.ResultadoDescripcion = "Excepcion encontrada";
                response.Data = listaDefault;
                response.Error = errors;
                context.Result = new JsonResult(response);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
            if (context.Exception.GetType() == typeof(RespuestaException))
            {
                var response = new ApiResponse<List<string>>(new List<string>());
                List<string> listaDefault = new List<string>();
                listaDefault = null;
                var exception = (RespuestaException)context.Exception;
                response.CodigoHTTP = (int)HttpStatusCode.OK;
                response.ResultadoIndicador = 1;
                response.ResultadoDescripcion = exception.Message;
                response.Data = listaDefault;
                context.Result = new JsonResult(response);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                context.ExceptionHandled = true;
            }


        }
    }
}
