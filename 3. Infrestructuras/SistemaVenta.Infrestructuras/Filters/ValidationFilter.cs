using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SistemaVenta.Core.Response;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SistemaVenta.Infraestructura.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState.Values.Where(v => v.Errors.Count > 0)
                  .SelectMany(v => v.Errors)
                  .Select(v => v.ErrorMessage)
                  .ToList();
                var response = new ApiResponse<List<string>>(new List<string>());
                response.CodigoHTTP = (int)HttpStatusCode.BadRequest;
                response.ResultadoDescripcion = "Excepcion encontrada";
                response.ResultadoIndicador = 0;
                response.Data = errors;

                context.Result = new JsonResult(response)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };
                return;
            }
            await next();
        }
    }
}
