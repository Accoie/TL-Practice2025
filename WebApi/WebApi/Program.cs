using FluentValidation;
using WebApi.Bindings;
using WebApi.Domain.Validators;
using WebApi.Middlewares;

public class Program
{
    private static void Main()
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder();

        builder.Services.AddWebComponents();
        builder.Services.AddAppServices();
        builder.Services.AddDatabase();
        builder.Services.AddInfrastructure();

        builder.Services.AddValidators();

        WebApplication app = builder.Build();

        if ( app.Environment.IsDevelopment() )
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.UseMiddleware<ExceptionMiddleware>();

        app.Run();
    }
}