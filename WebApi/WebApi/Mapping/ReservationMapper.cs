using WebApi.Data;
using WebApi.Domain.Entities;

namespace WebApi.Mapping;

public static class ReservationMapper
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
}