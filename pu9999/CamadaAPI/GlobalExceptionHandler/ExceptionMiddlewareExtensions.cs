using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Logging;

namespace UsiminasAPI.GlobalExceptionsHandler
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void UseGlobalExceptionMiddleware(this IApplicationBuilder builder, ILogger log)
        {
            builder.UseMiddleware<ExceptionMiddleware>(new object[] { log });
        }
    }
}