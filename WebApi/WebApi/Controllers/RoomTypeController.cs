using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Domain.Entities;
using WebApi.Domain.Foundations;
using WebApi.Domain.Services.Interfaces;
using WebApi.Extensions;
using WebApi.Mapping;

namespace WebApi.Controllers;

[Route( "api/roomtypes" )]
[ApiController]
public class RoomTypeController : ControllerBase
{
    private IRoomTypeService _roomTypeService;
    private IActualizer _actualizer;

    public RoomTypeController( IRoomTypeService roomTypeService, IActualizer actualizer )
    {
        _roomTypeService = roomTypeService;
        _actualizer = actualizer;
    }

    [HttpGet( "property/{propertyId}" )]
    public async Task<ActionResult<List<RoomType>>> ListRoomType( int propertyId )
    {
        List<RoomType> roomTypes = await _roomTypeService.GetAllById( propertyId );

        return Ok( roomTypes );
    }

    [HttpGet( "{id}" )]
    public async Task<ActionResult<RoomTypeDto>> GetRoomType( int id )
    {
        RoomType roomType = await _roomTypeService.GetById( id );

        return Ok( roomType.ToRoomTypeDto() );
    }

    [HttpPost( "property/{propertyId}" )]
    public async Task<IActionResult> CreateRoomType( [FromRoute] int propertyId, [FromBody] RoomTypeDto roomTypeDto )
    {
        RoomType roomType = RoomTypeMapper.ToRoomType( ControllerHelper.GenerateId(), roomTypeDto );
        roomType.PropertyId = propertyId;

        await _roomTypeService.CreateOrUpdate( roomType );

        return Ok();
    }

    [HttpPut( "{id}" )]
    public async Task<IActionResult> UpdateRoomType( int id, [FromBody] RoomTypeDto roomTypeDto )
    {
        RoomType roomType = RoomTypeMapper.ToRoomType( id, roomTypeDto );

        await _roomTypeService.CreateOrUpdate( roomType );
        await _actualizer.ActualizeById( id );

        return Ok();
    }

    [HttpDelete( "{id}" )]
    public async Task<IActionResult> DeleteRoomType( int id )
    {
        await _roomTypeService.Delete( id );

        return Ok();
    }
}