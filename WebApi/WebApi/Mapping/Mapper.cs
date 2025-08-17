using WebApi.Data;
using WebApi.Domain.Entities;

namespace WebApi.Mapping;

public static class Mapper
{
    public static Reservation ToReservation( int id, ReservationDto dto )
    {
        Reservation newReservation = new();

        newReservation.Id = id;
        newReservation.PropertyId = dto.PropertyId;
        newReservation.RoomTypeId = dto.RoomTypeId;
        newReservation.ArrivalDate = dto.ArrivalDate.Date;
        newReservation.ArrivalTime = dto.ArrivalTime;
        newReservation.Currency = dto.Currency;
        newReservation.DepartureDate = dto.DepartureDate.Date;
        newReservation.DepartureTime = dto.DepartureTime;
        newReservation.PersonCount = dto.PersonCount;
        newReservation.GuestName = dto.GuestName;
        newReservation.GuestPhoneNumber = dto.GuestPhoneNumber;

        return newReservation;
    }

    public static Property ToProperty( int id, PropertyDto dto )
    {
        Property property = new();

        property.Id = id;
        property.Name = dto.Name;
        property.Address = dto.Address;
        property.Country = dto.Country;
        property.City = dto.City;
        property.Latitude = dto.Latitude;
        property.Longitude = dto.Longitude;

        return property;
    }

    public static PropertyDto ToPropertyDto( Property property )
    {
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

    public static RoomTypeDto ToRoomTypeDto( RoomType roomType )
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