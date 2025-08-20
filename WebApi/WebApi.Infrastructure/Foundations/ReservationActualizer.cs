using WebApi.Domain.Entities;
using WebApi.Domain.Filters;
using WebApi.Domain.Foundations;
using WebApi.Domain.Services;

namespace WebApi.Infrastructure.Foundations;

public class ReservationActualizer : IActualizer
{
    IReservationService _reservationService;

    public ReservationActualizer( IReservationService reservationService )
    {
        _reservationService = reservationService;
    }

    public void ActualizeById( int id )
    {
        ReservationFilter filter = new();

        filter.RoomTypeId = id;

        List<Reservation> reservations = _reservationService.GetAll( filter );

        foreach ( Reservation reservation in reservations )
        {
            _reservationService.Update( reservation );
        }
    }
}