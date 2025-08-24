using WebApi.Data;
using WebApi.Domain.Entities;

namespace WebApi.Extensions
{
    public static class PropertyExtension
    {
        public static PropertyDto ToPropertyDto( this Property property )
        {
            return new PropertyDto
            {
                Name = property.Name,
                Country = property.Country,
                City = property.City,
                Address = property.Address,
                Longitude = property.Longitude,
                Latitude = property.Latitude
            };
        }
    }
}