using WebApi.Domain.Entities;

namespace WebApi.Domain.Repositories;

public interface IRoomTypeRepository
{
    public void Create( RoomType roomType );

    public List<RoomType> List();
    public Task<RoomType?> GetById( int id );

    public void Update( RoomType roomType );

    public void Delete( RoomType roomType );
}