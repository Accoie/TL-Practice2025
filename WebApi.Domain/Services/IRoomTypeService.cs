using WebApi.Domain.Entities;

namespace WebApi.Domain.Services;

public interface IRoomTypeService
{
    public void Create( RoomType roomType );

    public List<RoomType> GetList();
    public RoomType GetById( int id );

    public void Update( RoomType roomType );

    public void Delete( int id );
}
