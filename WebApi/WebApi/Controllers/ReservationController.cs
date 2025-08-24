using WebApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Domain.Filters;
using WebApi.Mapping;
using WebApi.Domain.Services.Interfaces;

namespace WebApi.Controllers;

[Route( "api/reservations" )]
[ApiController]
public class ReservationController : ControllerBase
{
    private IReservationService _reservationService;

    public ReservationController( IReservationService reservationService )
    {
        _reservationService = reservationService;
    }

    [HttpPost]
    public void CreateReservation( [FromBody] ReservationDto dto )
    {
        Reservation reservation = ReservationMapper.ToReservation( ControllerHelper.GenerateId(), dto );

        _reservationService.Create( reservation );
    }

    [HttpPut( "{id}" )]
    public void UpdateReservation( [FromQuery] int id, [FromBody] ReservationUpdationDto dto )
    {
        Reservation reservation = _reservationService.GetById( id );

        ReservationMapper.ChangeExistingReservation( dto, reservation );

        _reservationService.Update( reservation );
    }

    [HttpGet]
    public List<Reservation> GetReservations( [FromQuery] ReservationFilter filter )
    {
        return _reservationService.GetAll( filter );
    }

    [HttpDelete( "{id}" )]
    public void DeleteReservation( [FromQuery] int id )
    {
        _reservationService.Delete( id );
    }
}