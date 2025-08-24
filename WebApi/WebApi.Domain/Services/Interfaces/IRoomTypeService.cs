using WebApi.Domain.Entities;

namespace WebApi.Domain.Services.Interfaces;

public interface IRoomTypeService
{
    public void Create( RoomType roomType );

    public List<RoomType> GetAll();
    public List<RoomType> GetAllById( int propertyId );
    public RoomType GetById( int id );

    public void Update( RoomType roomType );

    public void Delete( int id );
}