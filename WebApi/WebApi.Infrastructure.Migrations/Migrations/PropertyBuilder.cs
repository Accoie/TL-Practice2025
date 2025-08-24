using Microsoft.EntityFrameworkCore;

namespace WebApi.Infrastructure.Migrations.Migrations;

public static class PropertyBuilder
{
    public static void BuildProperty( ModelBuilder modelBuilder )
    {
        modelBuilder.Entity( "WebApi.Domain.Entities.Property", b =>
        {
            b.Property<int>( "Id" )
                .ValueGeneratedOnAdd()
                .HasColumnType( "int" );

            SqlServerPropertyBuilderExtensions.UseIdentityColumn( b.Property<int>( "Id" ) );

            b.Property<string>( "Address" )
                .IsRequired()
                .HasMaxLength( 100 )
                .HasColumnType( "nvarchar(100)" );

            b.Property<string>( "City" )
                .IsRequired()
                .HasMaxLength( 50 )
                .HasColumnType( "nvarchar(50)" );

            b.Property<string>( "Country" )
                .IsRequired()
                .HasMaxLength( 50 )
                .HasColumnType( "nvarchar(50)" );

            b.Property<decimal>( "Latitude" )
                .HasColumnType( "decimal(9,6)" );

            b.Property<decimal>( "Longitude" )
                .HasColumnType( "decimal(9,6)" );

            b.Property<string>( "Name" )
                .IsRequired()
                .HasMaxLength( 50 )
                .HasColumnType( "nvarchar(50)" );

            b.HasKey( "Id" );

            b.HasIndex( "City" );

            b.HasIndex( "Country" );

            b.ToTable( "Property", ( string )null );
        } );
    }
}
