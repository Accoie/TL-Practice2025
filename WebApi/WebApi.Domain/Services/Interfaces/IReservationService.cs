using WebApi.Domain.Entities;
using WebApi.Domain.Filters;

namespace WebApi.Domain.Services.Interfaces;

public interface IReservationService
{
    public Task Create( Reservation reservation );

    public Task<List<Reservation>> GetAll( ReservationFilter? filter = null );
    public Task<Reservation> GetById( int id );

    public Task UpdateWithAction( int id, Action<Reservation> reservation );
    public Task Actualize( Reservation reservation );
    public Task Delete( int id );
}