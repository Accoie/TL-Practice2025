using WebApi.Data;
using WebApi.Domain.Entities;

namespace WebApi.Extensions;

public static class RoomTypeExtension
{
    public static RoomTypeDto ToRoomTypeDto( this RoomType roomType )
    {
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
}