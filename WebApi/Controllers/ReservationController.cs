using WebApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Domain.Services;
using WebApi.Domain.Filters;
using WebApi.Mapping;

namespace WebApi.Controllers;

[Route( "api/reservations" )]
[ApiController]
public class ReservationController : ControllerBase
{
    private IReservationService _reservationService;
    private int MinId = 1;
    private int MaxId = 1000000000;

    public ReservationController( IReservationService reservationService )
    {
        _reservationService = reservationService;
    }

    [HttpPost]
    public ActionResult CreateReservation( [FromQuery] ReservationDto reservationDto )
    {
        try
        {
            Random rnd = new Random();

            Reservation reservation = Mapper.ToReservation( rnd.Next( MinId, MaxId ), reservationDto );

            _reservationService.Create( reservation );

            return Ok();
        }
        catch ( ArgumentException ex )
        {
            return BadRequest( ex.Message );
        }
    }

    [HttpGet]
    public List<Reservation> GetReservations( [FromQuery] ReservationFilter filter )
    {
        return _reservationService.GetAll( filter );
    }

    [HttpDelete( "{id}" )]
    public ActionResult DeleteReservation( int id )
    {
        try
        {
            _reservationService.Delete( id );

            return Ok();
        }
        catch ( ArgumentException ex )
        {
            return BadRequest( ex.Message );
        }
    }
}