using WebApi.Domain.Entities;
using WebApi.Domain.Filters;
using WebApi.Domain.Foundations;
using WebApi.Domain.Services.Interfaces;

namespace WebApi.Infrastructure.Foundations;

public class ReservationActualizer : IActualizer
{
    IReservationService _reservationService;

    public ReservationActualizer( IReservationService reservationService )
    {
        _reservationService = reservationService;
    }

    public async Task ActualizeById( int id )
    {
        ReservationFilter filter = new();

        filter.RoomTypeId = id;

        IReadOnlyList<Reservation> reservations = await _reservationService.GetAll( filter );

        foreach ( Reservation reservation in reservations )
        {
            await _reservationService.CreateOrUpdate(reservation);
        }
    }
}