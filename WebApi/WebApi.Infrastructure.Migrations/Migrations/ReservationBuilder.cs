using Microsoft.EntityFrameworkCore;

namespace WebApi.Infrastructure.Migrations.Migrations;

public static class ReservationBuilder
{
    public static void BuildReservation( ModelBuilder modelBuilder )
    {
        modelBuilder.Entity( "WebApi.Domain.Entities.Reservation", b =>
        {
            b.Property<int>( "Id" )
                .ValueGeneratedOnAdd()
                .HasColumnType( "int" );

            SqlServerPropertyBuilderExtensions.UseIdentityColumn( b.Property<int>( "Id" ) );

            b.Property<DateTime>( "ArrivalDate" )
                .HasColumnType( "datetime2" );

            b.Property<TimeSpan>( "ArrivalTime" )
                .HasColumnType( "time" );

            b.Property<string>( "Currency" )
                .IsRequired()
                .HasMaxLength( 10 )
                .HasColumnType( "nvarchar(10)" );

            b.Property<DateTime>( "DepartureDate" )
                .HasColumnType( "datetime2" );

            b.Property<TimeSpan>( "DepartureTime" )
                .HasColumnType( "time" );

            b.Property<string>( "GuestName" )
                .IsRequired()
                .HasMaxLength( 200 )
                .HasColumnType( "nvarchar(200)" );

            b.Property<string>( "GuestPhoneNumber" )
                .IsRequired()
                .HasMaxLength( 50 )
                .HasColumnType( "nvarchar(50)" );

            b.Property<int>( "PersonCount" )
                .HasColumnType( "int" );

            b.Property<int>( "PropertyId" )
                .HasColumnType( "int" );

            b.Property<int>( "RoomTypeId" )
                .HasColumnType( "int" );

            b.Property<decimal>( "Total" )
                .HasColumnType( "decimal(18,2)" );

            b.HasKey( "Id" );

            b.ToTable( "Reservations", ( string )null );
        } );
    }
}