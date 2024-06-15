using System.Net;
using System.Text.Json;
using OnlineLibrary.Domain.Exceptions;

namespace OnlineLibrary;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
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

            var response = context.Response;
            response.ContentType = "application/json";

            var errorType = ex switch
            {
                EntityNotFoundException => (int)HttpStatusCode.NotFound,
                _ => (int) HttpStatusCode.InternalServerError
            };
            

            var json = JsonSerializer.Serialize(new
            {
                StatusCode = errorType, ex.Message
            });
            response.StatusCode = errorType;
            await response.WriteAsync(json);
        }
    }
}