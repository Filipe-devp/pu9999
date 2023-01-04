using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using Camada.Domain.Utils;

namespace UsiminasAPI.GlobalExceptionsHandler
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _log;

        public ExceptionMiddleware(RequestDelegate next, ILogger log)
        {
            _next = next;
            _log = log;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                SaveExceptionLog(ex);
                await HandleGlobalExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleGlobalExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(JsonConvert.SerializeObject(new BaseResponse()
            {
                Success = false,
                Message = exception.Message
            }));
        }

        private void SaveExceptionLog(Exception ex)
        {
            var parameter = new
            {
                Error = ex.Message,
                Stack = ex.StackTrace
            };
            _log.LogError(JsonConvert.SerializeObject(parameter));
        }
    }
}


