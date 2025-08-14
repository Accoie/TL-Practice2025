using WebApi.Infrastructure.Foundations.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Entities;

namespace WebApi.Infrastructure;

public class WebApiDbContext : DbContext
{
    public DbSet<Property> Properties { get; set; }
    public DbSet<RoomType> RoomTypes { get; set; }

    public WebApiDbContext( DbContextOptions<WebApiDbContext> options ) : base( options )
    {
    }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating( modelBuilder );

        modelBuilder.ApplyConfiguration( new PropertyConfiguration() );
        modelBuilder.ApplyConfiguration( new RoomTypeConfiguration() );
    }
}