using BrainboxApi.Helpers;
using System.Net;

namespace BrainboxApi.Middlewares
{
    public class CustomExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandler> _logger;

        public CustomExceptionHandler(RequestDelegate next, ILogger<CustomExceptionHandler> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex} \n Inner Exception => {ex.InnerException} \n Stack Trace => {ex.StackTrace}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }


        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var message = exception switch
            {
                AccessViolationException => "Access violation error from the custom middleware",
                ArgumentNullException => "Null argument error from the custom middleware",
                Microsoft.Data.SqlClient.SqlException => "Entity already exists, you cannot create a duplicate",
                _ => "Internal Server Error from the Custom middleware."
            };

            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = $"{message} \n {exception.Message}"
            }.ToString());
        }
    }
}
