using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Foundations.EntityConfigurations;

public class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
{
    public void Configure( EntityTypeBuilder<RoomType> builder )
    {
        builder.ToTable( "RoomTypes" )
               .HasKey( rt => rt.Id );

        builder.HasOne<Property>()
               .WithMany()
               .HasForeignKey( rt => rt.PropertyId )
               .OnDelete( DeleteBehavior.Cascade );

        builder.Property( rt => rt.Name )
               .HasMaxLength( 100 )
               .IsRequired();

        builder.Property( rt => rt.Currency )
               .HasMaxLength( 3 )
               .IsRequired()
               .HasDefaultValue( "USD" );

        builder.Property( rt => rt.DailyPrice )
               .HasColumnType( "decimal(18,2)" )
               .IsRequired();

        builder.Property( rt => rt.MinPersonCount )
               .IsRequired();

        builder.Property( rt => rt.MaxPersonCount )
               .IsRequired();

        builder.Property( rt => rt.ServicesString )
            .HasColumnType( "nvarchar(max)" )
            .HasColumnName( "Services" );

        builder.Property( rt => rt.AmenitiesString )
               .HasColumnType( "nvarchar(max)" )
               .HasColumnName( "Amenities" );

        builder.HasIndex( rt => rt.PropertyId );
        builder.HasIndex( rt => rt.DailyPrice );
    }
}