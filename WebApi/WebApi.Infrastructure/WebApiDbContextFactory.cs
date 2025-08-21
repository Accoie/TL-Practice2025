using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebApi.Infrastructure;

public class BookingManagerDbContextFactory : IDesignTimeDbContextFactory<WebApiDbContext>
{
    public WebApiDbContext CreateDbContext( string[] args )
    {
        var optionsBuilder = new DbContextOptionsBuilder<WebApiDbContext>();
        optionsBuilder.UseSqlServer( "Server=local\\SQLEXPRESS;Database=WebApi;TrustServerCertificate=True;" );

        return new WebApiDbContext( optionsBuilder.Options );
    }
}