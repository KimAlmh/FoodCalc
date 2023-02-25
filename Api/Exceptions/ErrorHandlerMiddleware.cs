using System.Net;
using System.Text.Json;

namespace Api.Exceptions;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (UniqueConstraintException error)
        {
            var url = $"{context.Request.Scheme}://{context.Request.Host.Value}{context.Request.Path.Value}{error.Id}";
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = 303;
            var result = JsonSerializer.Serialize(new
                { message = error.Message, location = url });
            await response.WriteAsync(result);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            response.StatusCode = error switch
            {
                FoodNotFoundException e =>
                    (int)HttpStatusCode.NotFound,

                KeyNotFoundException e =>
                    (int)HttpStatusCode.NotFound,

                _ => (int)HttpStatusCode.InternalServerError
            };

            var result = JsonSerializer.Serialize(new { message = error?.Message });
            await response.WriteAsync(result);
        }
    }
}