using System.Net;

namespace EconomicApp.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger logger;
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception exp)
            {
                var errorId = Guid.NewGuid();

                // Log Exception
                logger.LogError(exp, $"{errorId} : {exp.Message}");

                //Return A Custom Error Response
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorId,
                    Message = exp.Message,
                };

                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }

    }
}
