using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Domain.Entities;
using WebApi.Domain.Services;

namespace WebApi.Infrastructure.Controllers;

[Route( "/api/properties" )]
[ApiController]
public class PropertyController : ControllerBase
{
    private IPropertyService _propertyService;

    public PropertyController( IPropertyService propertyService )
    {
        _propertyService = propertyService;
    }

    [HttpGet]
    public List<Property> ListProperty()
    {
        return _propertyService.GetList();
    }

    [HttpGet( "{id}" )]
    public ActionResult<PropertyDto> GetProperty( int id )
    {
        try
        {
            Property property = _propertyService.GetById( id );

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
        catch ( ArgumentException ex )
        {
            return NotFound( ex.Message );
        }
    }

    [HttpPost]
    public ActionResult CreateProperty( Property property )
    {
        try
        {
            _propertyService.Create( property );

            return Ok();
        }
        catch ( ArgumentException ex )
        {
            return BadRequest( ex.Message );
        }
    }

    [HttpPut( "{id}" )]
    public ActionResult UpdateProperty( int id, PropertyDto propertyDto )
    {
        try
        {
            Property property = new();

            property.Id = id;
            property.Name = propertyDto.Name;
            property.Address = propertyDto.Address;
            property.Country = propertyDto.Country;
            property.City = propertyDto.City;
            property.Latitude = propertyDto.Latitude;
            property.Longitude = propertyDto.Longitude;

            _propertyService.Update( property );

            return Ok();
        }
        catch ( ArgumentException ex )
        {
            return BadRequest( ex.Message );
        }
    }

    [HttpDelete( "{id}" )]
    public ActionResult DeleteProperty( int id )
    {
        try
        {
            _propertyService.Delete( id );

            return Ok();
        }
        catch ( ArgumentException ex )
        {
            return BadRequest( ex.Message );
        }
    }
}