using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WebApi.Infrastructure.Migrations;

public class BookingManagerDbContextFactory : IDesignTimeDbContextFactory<WebApiDbContext>
{
    public WebApiDbContext CreateDbContext( string[] args )
    {
        string? basePath = Path.GetFullPath( Path.Combine(
            Directory.GetCurrentDirectory(),
            "..", "..", ".." ) );

        string? webApiPath = Path.Combine( basePath, "WebApi" );

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath( webApiPath )
            .AddJsonFile( "appsettings.json", optional: false )
            .Build();

        string? connectionString = configuration.GetConnectionString( "DefaultConnection" );

        DbContextOptionsBuilder<WebApiDbContext> optionsBuilder = new();
        optionsBuilder.UseSqlServer(
            connectionString,
            b => b.MigrationsAssembly( "WebApi.Infrastructure.Migrations" ) );

        return new WebApiDbContext( optionsBuilder.Options );
    }
}