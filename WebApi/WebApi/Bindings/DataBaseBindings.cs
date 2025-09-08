using Microsoft.EntityFrameworkCore;
using WebApi.Infrastructure;

namespace WebApi.Bindings;

public static class DatabaseBindings
{
    public static IServiceCollection AddDatabase( this IServiceCollection services )
    {
        services.AddDbContext<WebApiDbContext>( options =>
        {
            options.UseInMemoryDatabase( databaseName: "WebApiDatabase" );
            options.LogTo( Console.WriteLine );
        } );

        return services;
    }
}