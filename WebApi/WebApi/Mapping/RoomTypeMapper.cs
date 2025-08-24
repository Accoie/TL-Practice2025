using WebApi.Data;
using WebApi.Domain.Entities;

namespace WebApi.Mapping;

public static class RoomTypeMapper
{
    public static void ChangeExistingRoomType( RoomTypeDto dto, RoomType roomType )
    {
        roomType.Currency = dto.Currency;
        roomType.Name = dto.Name;
        roomType.DailyPrice = dto.DailyPrice;
        roomType.Services = dto.Services;
        roomType.Amenities = dto.Amenities;
        roomType.MaxPersonCount = dto.MaxPersonCount;
        roomType.MinPersonCount = dto.MinPersonCount;
    }

    public static RoomType ToRoomType( int id, RoomTypeDto dto )
    {
        RoomType roomType = new();

        roomType.Id = id;
        roomType.Name = dto.Name;
        roomType.Currency = dto.Currency;
        roomType.Services = dto.Services;
        roomType.DailyPrice = dto.DailyPrice;
        roomType.Amenities = dto.Amenities;
        roomType.MaxPersonCount = dto.MaxPersonCount;
        roomType.MinPersonCount = dto.MinPersonCount;

        return roomType;
    }
}