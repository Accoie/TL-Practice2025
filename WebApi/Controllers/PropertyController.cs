using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Domain.Entities;
using WebApi.Domain.Services;
using WebApi.Mapping;

namespace WebApi.Controllers;

[Route( "/api/properties" )]
[ApiController]
public class PropertyController : ControllerBase
{
    private IPropertyService _propertyService;
    private int MinId = 1;
    private int MaxId = 1000000000;

    public PropertyController( IPropertyService propertyService )
    {
        _propertyService = propertyService;
    }

    [HttpGet]
    public List<Property> ListProperty()
    {
        return _propertyService.GetAll();
    }

    [HttpGet( "{id}" )]
    public ActionResult<PropertyDto> GetProperty( int id )
    {
        try
        {
            Property property = _propertyService.GetById( id );

            return Mapper.ToPropertyDto( property );
        }
        catch ( ArgumentException ex )
        {
            return NotFound( ex.Message );
        }
    }

    [HttpPost]
    public ActionResult CreateProperty( PropertyDto propertyDto )
    {
        try
        {
            Random rnd = new Random();

            Property property = Mapper.ToProperty( rnd.Next( MinId, MaxId ), propertyDto ); ;

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
            Property property = Mapper.ToProperty( id, propertyDto );

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