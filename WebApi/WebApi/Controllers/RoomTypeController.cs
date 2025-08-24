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
    public List<RoomType> ListRoomType( [FromQuery] int propertyId )
    {
        return _roomTypeService.GetAllById( propertyId );
    }

    [HttpGet( "{id}" )]
    public RoomTypeDto GetRoomType( [FromQuery] int id )
    {
        RoomType roomType = _roomTypeService.GetById( id );

        return roomType.ToRoomTypeDto();
    }

    [HttpPost( "property/{propertyId}" )]
    public void CreateRoomType( [FromRoute] int propertyId, [FromBody] RoomTypeDto roomTypeDto )
    {
        RoomType roomType = RoomTypeMapper.ToRoomType( ControllerHelper.GenerateId(), roomTypeDto );

        roomType.PropertyId = propertyId;

        _roomTypeService.Create( roomType );
    }

    [HttpPut( "{id}" )]
    public void UpdateRoomType( [FromQuery] int id, [FromBody] RoomTypeDto roomTypeDto )
    {
        RoomType roomType = _roomTypeService.GetById( id );

        RoomTypeMapper.ChangeExistingRoomType( roomTypeDto, roomType );

        _roomTypeService.Update( roomType );

        _actualizer.ActualizeById( id );
    }

    [HttpDelete( "{id}" )]
    public void DeleteRoomType( [FromQuery] int id )
    {
        _roomTypeService.Delete( id );
    }
}