using WebApi.Domain.Entities;

namespace WebApi.Domain.Repositories;

public interface IReservationRepository
{
    public void Create( Reservation reservation );

    public List<Reservation> GetAll();
    public Reservation? GetById( int id );

    public void Update( Reservation reservation );

    public void Delete( Reservation reservation );
}