using WebApi.Domain.Entities;

namespace WebApi.Domain.Services.Interfaces;

public interface IRoomTypeService
{
    public Task Create( RoomType roomType );

    public Task<List<RoomType>> GetAll();
    public Task<List<RoomType>> GetAllById( int propertyId );
    public Task<RoomType> GetById( int id );
    
    public Task Update( int id, Action<RoomType> updateAction );

    public Task Delete( int id );
}