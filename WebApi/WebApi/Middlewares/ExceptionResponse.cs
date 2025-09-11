using System.Net;

namespace WebApi.Middlewares;

public record ExceptionResponse(
    string Message,
    HttpStatusCode StatusCode,
    DateTime Time
);