using WebApi.Domain.Entities;
using WebApi.Domain.Filters;

namespace WebApi.Domain.Services.Interfaces;

public interface IReservationService
{
    public void Create( Reservation reservation );

    public List<Reservation> GetAll( ReservationFilter? filter = null );
    public Reservation GetById( int id );

    public void Update( Reservation reservation );

    public void Delete( int id );
}