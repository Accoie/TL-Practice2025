using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Domain.Entities;
using WebApi.Domain.Services;
using WebApi.Mapping;

namespace WebApi.Controllers;

[Route( "api/roomtypes" )]
[ApiController]
public class RoomTypeController : ControllerBase
{
    private IRoomTypeService _roomTypeService;
    private int MinId = 1;
    private int MaxId = 1000000000;

    public RoomTypeController( IRoomTypeService roomTypeService )
    {
        _roomTypeService = roomTypeService;
    }

    [HttpGet( "property/{propertyId}" )]
    public List<RoomType> ListRoomType( int propertyId )
    {
        return _roomTypeService.GetAllById( propertyId );
    }

    [HttpGet( "{id}" )]
    public ActionResult<RoomTypeDto> GetRoomType( int id )
    {
        try
        {
            RoomType roomType = _roomTypeService.GetById( id );

            return Mapper.ToRoomTypeDto( roomType );
        }
        catch ( ArgumentException ex )
        {
            return NotFound( ex.Message );
        }
    }

    [HttpPost( "property/{propertyId}" )]
    public ActionResult CreateRoomType( [FromRoute] int propertyId, RoomTypeDto roomTypeDto )
    {
        try
        {
            Random rnd = new Random();

            RoomType roomType = Mapper.ToRoomType( rnd.Next( MinId, MaxId ), roomTypeDto );

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
            RoomType roomType = _roomTypeService.GetById( id );

            Mapper.ChangeExistingRoomType( roomTypeDto, roomType );

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