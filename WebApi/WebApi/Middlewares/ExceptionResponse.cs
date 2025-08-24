using System.Net;

namespace WebApi.Middlewares;

public class ExceptionResponse
{
    public string Exception { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public DateTime Time { get; set; }
}