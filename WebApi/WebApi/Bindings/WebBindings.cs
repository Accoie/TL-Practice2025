namespace WebApi.Bindings;

public static class WebBindings
{
    public static IServiceCollection AddWebComponents( this IServiceCollection services )
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}