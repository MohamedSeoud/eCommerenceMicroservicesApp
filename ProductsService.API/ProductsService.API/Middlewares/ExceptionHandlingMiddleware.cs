using Microsoft.Extensions.Logging;

namespace ProductsService.API.Middlewares;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;  

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            // Log the error
            _logger.LogError($"Exception: {ex.GetType().Name} - {ex.Message}");
            if (ex.InnerException != null)
            {
                _logger.LogError($"Inner Exception: {ex.InnerException.GetType().Name} - {ex.InnerException.Message}");
            }

            // Set the response status code and content type
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            httpContext.Response.ContentType = "application/json";

            // Define the error response object
            var errorResponse = new
            {
                StatusCode = httpContext.Response.StatusCode,
                ErrorType = ex.GetType().Name,
                Message = ex.Message
            };

            // Serialize the response
            await httpContext.Response.WriteAsJsonAsync(errorResponse);
        }
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class ExceptionHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
