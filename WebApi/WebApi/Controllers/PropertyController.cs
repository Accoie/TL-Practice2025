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
    public async Task<ActionResult<List<Property>>> GetProperties()
    {
        IReadOnlyList<Property> properties = await _propertyService.GetAll();

        return Ok( properties );
    }

    [HttpGet( "{id}" )]
    public async Task<ActionResult<PropertyDto>> GetProperty( int id )
    {
        Property property = await _propertyService.GetById( id );

        return Ok( property.ToPropertyDto() );
    }

    [HttpPost]
    public async Task<IActionResult> CreateProperty( [FromBody] PropertyDto propertyDto )
    {
        Property property = PropertyMapper.ToProperty( ControllerHelper.GenerateId(), propertyDto );

        await _propertyService.CreateOrUpdate( property );

        return Ok();
    }

    [HttpPut( "{id}" )]
    public async Task<IActionResult> UpdateProperty( int id, [FromBody] PropertyDto propertyDto )
    {
        Property property = PropertyMapper.ToProperty( id, propertyDto );

        await _propertyService.CreateOrUpdate( property );

        return Ok();
    }

    [HttpDelete( "{id}" )]
    public async Task<IActionResult> DeleteProperty( int id )
    {
        await _propertyService.Delete( id );

        return Ok();
    }
}