using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Domain.Entities;
using WebApi.Domain.Services;

namespace WebApi.Infrastructure.Controllers;

[Route( "api/properties/{propertyId}/roomtypes" )]
[ApiController]
public class RoomTypeController : ControllerBase
{
    private IRoomTypeService _roomTypeService;

    public RoomTypeController( IRoomTypeService roomTypeService )
    {
        _roomTypeService = roomTypeService;
    }

    [HttpGet]
    public List<RoomType> ListRoomType()
    {
        return _roomTypeService.GetList();
    }

    [HttpGet( "{id}" )]
    public ActionResult<RoomTypeDto> GetRoomType( int id )
    {
        try
        {
            RoomType roomType = _roomTypeService.GetById( id );

            return new RoomTypeDto
            {
                Name = roomType.Name,
                Currency = roomType.Currency,
                MaxPersonCount = roomType.MaxPersonCount,
                MinPersonCount = roomType.MinPersonCount,
                Amenities = roomType.Amenities,
                DailyPrice = roomType.DailyPrice,
                Services = roomType.Services,
            };
        }
        catch ( ArgumentException ex )
        {
            return NotFound( ex.Message );
        }
    }

    [HttpPost]
    public ActionResult CreateRoomType( [FromRoute] int propertyId, RoomType roomType )
    {
        try
        {
            roomType.PropertyId = propertyId;

            _roomTypeService.Create( roomType );

            return Ok();
        }
        catch ( ArgumentException ex )
        {
            return BadRequest( ex.Message );
        }
    }

    [HttpPut( "{id}" )]
    public ActionResult UpdateRoomType( int id, RoomTypeDto roomTypeDto )
    {
        try
        {
            RoomType roomType = new();

            roomType.Id = id;
            roomType.Name = roomTypeDto.Name;
            roomType.Currency = roomTypeDto.Currency;
            roomType.Services = roomTypeDto.Services;
            roomType.DailyPrice = roomTypeDto.DailyPrice;
            roomType.Amenities = roomTypeDto.Amenities;

            _roomTypeService.Update( roomType );

            return Ok();
        }
        catch ( ArgumentException ex )
        {
            return BadRequest( ex.Message );
        }
    }

    [HttpDelete( "{id}" )]
    public ActionResult DeleteRoomType( int id )
    {
        try
        {
            _roomTypeService.Delete( id );
            return Ok();
        }
        catch ( ArgumentException ex )
        {
            return BadRequest( ex.Message );
        }
    }
}
