using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Domain.Entities;
using WebApi.Domain.Services.Interfaces;
using WebApi.Extensions;
using WebApi.Mapping;

namespace WebApi.Controllers;

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
        return _propertyService.GetAll();
    }

    [HttpGet( "{id}" )]
    public PropertyDto GetProperty( [FromQuery] int id )
    {
        Property property = _propertyService.GetById( id );

        return property.ToPropertyDto();
    }

    [HttpPost]
    public void CreateProperty( [FromBody] PropertyDto propertyDto )
    {
        Property property = PropertyMapper.ToProperty( ControllerHelper.GenerateId(), propertyDto ); ;

        _propertyService.Create( property );
    }

    [HttpPut( "{id}" )]
    public void UpdateProperty( [FromQuery] int id, [FromBody] PropertyDto propertyDto )
    {
        Property property = _propertyService.GetById( id );

        PropertyMapper.ChangeExistingProperty( propertyDto, property );

        _propertyService.Update( property );
    }

    [HttpDelete( "{id}" )]
    public void DeleteProperty( [FromQuery] int id )
    {
        _propertyService.Delete( id );
    }
}