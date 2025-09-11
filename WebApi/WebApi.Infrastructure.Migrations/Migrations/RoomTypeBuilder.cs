using Microsoft.EntityFrameworkCore;

namespace WebApi.Infrastructure.Migrations.Migrations;
public static class RoomTypeBuilder
{
    public static void BuildRoomType( ModelBuilder modelBuilder )
    {
        modelBuilder.Entity( "WebApi.Domain.Entities.RoomType", b =>
        {
            b.Property<int>( "Id" )
                .ValueGeneratedOnAdd()
                .HasColumnType( "int" );

            SqlServerPropertyBuilderExtensions.UseIdentityColumn( b.Property<int>( "Id" ) );

            b.Property<string>( "Amenities" )
                .IsRequired()
                .HasColumnType( "nvarchar(max)" );

            b.Property<string>( "Currency" )
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasMaxLength( 3 )
                .HasColumnType( "nvarchar(3)" )
                .HasDefaultValue( "USD" );

            b.Property<decimal>( "DailyPrice" )
                .HasColumnType( "decimal(18,2)" );

            b.Property<int>( "MaxPersonCount" )
                .HasColumnType( "int" );

            b.Property<int>( "MinPersonCount" )
                .HasColumnType( "int" );

            b.Property<string>( "Name" )
                .IsRequired()
                .HasMaxLength( 100 )
                .HasColumnType( "nvarchar(100)" );

            b.Property<int>( "PropertyId" )
                .HasColumnType( "int" );

            b.Property<string>( "Services" )
                .IsRequired()
                .HasColumnType( "nvarchar(max)" );

            b.HasKey( "Id" );

            b.HasIndex( "DailyPrice" );

            b.HasIndex( "PropertyId" );

            b.ToTable( "RoomTypes", ( string )null );
        } );

        modelBuilder.Entity( "WebApi.Domain.Entities.RoomType", b =>
        {
            b.HasOne( "WebApi.Domain.Entities.Property", null )
                .WithMany()
                .HasForeignKey( "PropertyId" )
                .OnDelete( DeleteBehavior.Cascade )
                .IsRequired();
        } );
    }
}