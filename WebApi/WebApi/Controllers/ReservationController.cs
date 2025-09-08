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
    public async Task<IActionResult> CreateReservation( [FromBody] ReservationDto dto )
    {
        Reservation reservation = ReservationMapper.ToReservation( ControllerHelper.GenerateId(), dto );

        await _reservationService.Create( reservation );

        return Ok();
    }

    [HttpPut( "{id}" )]
    public async Task<IActionResult> UpdateReservation( [FromQuery] int id, [FromBody] ReservationUpdationDto dto )
    {
        await _reservationService.UpdateWithAction( id, reservation =>
        {
            ReservationMapper.ChangeExistingReservation( dto, reservation );
        } );

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetReservations( [FromQuery] ReservationFilter filter )
    {
        await _reservationService.GetAll( filter );

        return Ok();
    }

    [HttpDelete( "{id}" )]
    public async Task<IActionResult> DeleteReservation( [FromQuery] int id )
    {
        await _reservationService.Delete( id );

        return Ok();
    }
}