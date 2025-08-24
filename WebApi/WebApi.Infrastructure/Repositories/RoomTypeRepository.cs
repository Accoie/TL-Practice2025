using WebApi.Domain.Entities;
using WebApi.Domain.Repositories;

namespace WebApi.Infrastructure.Repositories;

public class RoomTypeRepository : IRoomTypeRepository
{
    WebApiDbContext _webApiDbContext;

    public RoomTypeRepository( WebApiDbContext webApiDbContext )
    {
        _webApiDbContext = webApiDbContext;
    }

    public void Create( RoomType roomType )
    {
        _webApiDbContext.Add( roomType );
    }

    public List<RoomType> GetAll()
    {
        return _webApiDbContext.RoomTypes.ToList();
    }

    public RoomType? GetById( int id )
    {
        return _webApiDbContext.Find<RoomType>( id );
    }

    public void Update( RoomType roomType )
    {
        _webApiDbContext.Update( roomType );
    }

    public void Delete( RoomType roomType )
    {
        _webApiDbContext.Remove( roomType );
    }
}