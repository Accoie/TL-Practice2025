using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Foundations.EntityConfigurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure( EntityTypeBuilder<Reservation> builder )
    {
        builder.ToTable( "Reservations" );

        builder.HasKey( r => r.Id );

        builder.Property( r => r.Id )
            .ValueGeneratedOnAdd();

        builder.Property( r => r.PropertyId )
            .IsRequired();

        builder.Property( r => r.RoomTypeId )
            .IsRequired();

        builder.Property( r => r.ArrivalDate )
            .IsRequired();

        builder.Property( r => r.DepartureDate )
            .IsRequired();

        builder.Property( r => r.ArrivalTime )
            .IsRequired();

        builder.Property( r => r.DepartureTime )
            .IsRequired();

        builder.Property( r => r.PersonCount )
            .IsRequired();

        builder.Property( r => r.GuestName )
            .HasMaxLength( 200 )
            .IsRequired();

        builder.Property( r => r.GuestPhoneNumber )
            .HasMaxLength( 50 )
            .IsRequired();

        builder.Property( r => r.Total )
            .HasColumnType( "decimal(18,2)" )
            .IsRequired();

        builder.Property( r => r.Currency )
            .HasMaxLength( 10 )
            .IsRequired();
    }
}