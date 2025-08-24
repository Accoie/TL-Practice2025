using System.Net;

namespace WebApi.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware( RequestDelegate next )
    {
        _next = next;
    }

    public async Task InvokeAsync( HttpContext context )
    {
        try
        {
            await _next( context );
        }
        catch ( ArgumentException ex )
        {
            await HandleExceptionAsync( context, ex, HttpStatusCode.BadRequest );
        }
        catch ( KeyNotFoundException ex )
        {
            await HandleExceptionAsync( context, ex, HttpStatusCode.NotFound );
        }
        catch ( UnauthorizedAccessException ex )
        {
            await HandleExceptionAsync( context, ex, HttpStatusCode.Unauthorized );
        }
        catch ( Exception ex )
        {
            await HandleExceptionAsync( context, ex, HttpStatusCode.InternalServerError );
        }
    }

    private static Task HandleExceptionAsync( HttpContext context, Exception exception, HttpStatusCode statusCode )
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = ( int )statusCode;

        ExceptionResponse response = new ExceptionResponse
        {
            Exception = exception.Message,
            StatusCode = statusCode,
            Time = DateTime.UtcNow
        };

        return context.Response.WriteAsJsonAsync( response );
    }
}