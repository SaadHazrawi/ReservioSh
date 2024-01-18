using Reservio.Core;
using System.Net;
using System.Text.Json;

namespace Reservio.Middlewares
{

    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        /// <summary>
        /// Constructs an instance of the ErrorHandlerMiddleware class.
        /// </summary>
        /// <param name="next">The next middleware delegate.</param>
        /// <param name="logger">An instance of the ILogger interface used for logging.</param>
        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Invokes the middleware function.
        /// </summary>
        /// <param name="context">The HttpContext.</param>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                _logger.LogError(error, error.Message);

                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new ErrorResponse(error.Message);

                switch (error)
                {
                    case APIException e:
                        // custom application error
                        response.StatusCode = e.StatusCode;
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);
            }
        }
    }
}
