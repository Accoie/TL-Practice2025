using System.Net;

namespace WebApi.Middlewares;

public record ValidationExceptionResponse(
    string Message,
    List<string> Errors,
    HttpStatusCode StatusCode,
    DateTime Time
);