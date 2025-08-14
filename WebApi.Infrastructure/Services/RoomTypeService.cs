using WebApi.Domain.Entities;
using WebApi.Domain.Foundations;
using WebApi.Domain.Repositories;
using WebApi.Domain.Services;

namespace WebApi.Infrastructure.Services;

public class RoomTypeService : IRoomTypeService
{
    private readonly IRoomTypeRepository _roomTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RoomTypeService( IRoomTypeRepository roomTypeRepository, IUnitOfWork unitOfWork )
    {
        _roomTypeRepository = roomTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public void Create( RoomType roomType )
    {
        bool isExists = _roomTypeRepository.GetById( roomType.Id ).Result != null;

        if ( isExists )
        {
            throw new ArgumentException( "RoomType is already exists" );
        }

        _roomTypeRepository.Create( roomType );

        _unitOfWork.CommitAsync();
    }

    public void Delete( int id )
    {
        RoomType roomType = GetById( id );

        _roomTypeRepository.Delete( roomType );

        _unitOfWork.CommitAsync();
    }

    public RoomType GetById( int id )
    {
        RoomType? roomType = _roomTypeRepository.GetById( id ).Result;

        if ( roomType == null )
        {
            throw new ArgumentException( "RoomType doesn't exists" );
        }

        return roomType;
    }

    public List<RoomType> GetList()
    {
        return _roomTypeRepository.List();
    }

    public void Update( RoomType newRoomType )
    {
        RoomType roomType = GetById( newRoomType.Id );

        roomType.Currency = newRoomType.Currency;
        roomType.Name = newRoomType.Name;
        roomType.DailyPrice = newRoomType.DailyPrice;
        roomType.Services = newRoomType.Services;
        roomType.Amenities = newRoomType.Amenities;
        roomType.MaxPersonCount = newRoomType.MaxPersonCount;
        roomType.MinPersonCount = newRoomType.MinPersonCount;

        _roomTypeRepository.Update( roomType );

        _unitOfWork.CommitAsync();
    }
}
