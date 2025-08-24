using WebApi.Data;
using WebApi.Domain.Entities;

namespace WebApi.Mapping
{
    public static class PropertyMapper
    {
        public static Property ToProperty( int id, PropertyDto dto )
        {
            Property property = new();

            property.Id = id;
            property.Name = dto.Name;
            property.Address = dto.Address;
            property.Country = dto.Country;
            property.City = dto.City;
            property.Latitude = dto.Latitude;
            property.Longitude = dto.Longitude;

            return property;
        }

        public static void ChangeExistingProperty( PropertyDto dto, Property property )
        {
            property.Longitude = dto.Longitude;
            property.Latitude = dto.Latitude;
            property.Address = dto.Address;
            property.City = dto.City;
            property.Country = dto.Country;
            property.Name = dto.Name;
        }

    }
}