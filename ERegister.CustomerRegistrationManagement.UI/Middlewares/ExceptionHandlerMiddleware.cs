using ERegister.CustomerRegistrationManagement.Core.Domain.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace ERegister.CustomerRegistrationManagement.UI.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);

            }catch (Exception ex)
            {
                await ConvertException(context, ex);
            }
        }

        private Task ConvertException(HttpContext context, Exception ex)
        {
            HttpStatusCode httpStatusCode = new HttpStatusCode();

            context.Response.ContentType = "application/json";

            var result = string.Empty;

            switch(ex)
            {
                case NotFoundException notFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    break;
            }

            context.Response.StatusCode = (int)httpStatusCode;

            if(result == String.Empty)
            {
                result = JsonConvert.SerializeObject(new { error = ex.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
}
