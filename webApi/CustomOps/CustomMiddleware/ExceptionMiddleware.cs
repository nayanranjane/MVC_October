using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace webApi.CustomOps.CustomMiddleware
{
    internal class ErrorDetails
    {
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }

    }
    public class ExceptionMiddleware
    {
        RequestDelegate _next;
        public ExceptionMiddleware( RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                string errorMessage = ex.Message;
                ErrorDetails errorDetails = new ErrorDetails()
                {
                    ErrorMessage = errorMessage,
                    StatusCode = context.Response.StatusCode
                };
                await context.Response.WriteAsJsonAsync(errorDetails);
            }
        }
    }
    public static class ErrorMiddleWareExtension
    {
        public static void UseAppExtenstionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
