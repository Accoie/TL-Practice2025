using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Domain.Entities;

namespace WebApi.Infrastructure.Foundations.EntityConfigurations;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure( EntityTypeBuilder<Property> builder )
    {
        builder.ToTable( nameof( Property ) )
               .HasKey( p => p.Id );

        builder.Property( p => p.Name )
               .HasMaxLength( 50 )
               .IsRequired();

        builder.Property( p => p.Country )
               .HasMaxLength( 50 )
               .IsRequired();

        builder.Property( p => p.City )
               .HasMaxLength( 50 )
               .IsRequired();

        builder.Property( p => p.Address )
               .HasMaxLength( 100 )
               .IsRequired();

        builder.Property( p => p.Latitude )
               .HasColumnType( "decimal(9,6)" )
               .IsRequired();

        builder.Property( p => p.Longitude )
               .HasColumnType( "decimal(9,6)" )
               .IsRequired();

        builder.HasIndex( p => p.Country );
        builder.HasIndex( p => p.City );
    }
}