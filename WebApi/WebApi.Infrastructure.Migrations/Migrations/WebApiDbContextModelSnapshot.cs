using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

#nullable disable

namespace WebApi.Infrastructure.Migrations.Migrations;

[DbContext(typeof(WebApiDbContext))]
partial class WebApiDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "9.0.8")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

        PropertyBuilder.BuildProperty( modelBuilder );
        RoomTypeBuilder.BuildRoomType(modelBuilder);
        ReservationBuilder.BuildReservation(modelBuilder);
    }
}