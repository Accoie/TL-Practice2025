using WebApi.Domain.Entities;
using WebApi.Domain.Repositories;

namespace WebApi.Infrastructure.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly WebApiDbContext _webApiDbContext;

    public ReservationRepository( WebApiDbContext webApiDbContext )
    {
        _webApiDbContext = webApiDbContext;
    }

    public void Create( Reservation reservation )
    {
        _webApiDbContext.Add( reservation );
    }

    public List<Reservation> GetAll()
    {
        return _webApiDbContext.Reservations.ToList();
    }

    public Reservation? GetById( int id )
    {
        return _webApiDbContext.Find<Reservation>( id );
    }

    public void Update( Reservation reservation )
    {
        _webApiDbContext.Update( reservation );
    }

    public void Delete( Reservation reservation )
    {
        _webApiDbContext.Remove( reservation );
    }
}