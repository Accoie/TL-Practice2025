using WebApi.Domain.Entities;

namespace WebApi.Domain.Services.Interfaces;

public interface IRoomTypeService
{
    public Task CreateOrUpdate( RoomType roomType );

    public Task<List<RoomType>> GetAll();
    public Task<List<RoomType>> GetAllById( int propertyId );
    public Task<RoomType> GetById( int id );

    public Task Delete( int id );
}