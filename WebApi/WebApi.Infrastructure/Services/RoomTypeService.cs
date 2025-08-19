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
        CheckRoomTypeExists( roomType.Id );
        ValidateRoomType( roomType );

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
        RoomType? roomType = _roomTypeRepository.GetById( id );

        if ( roomType is null )
        {
            throw new ArgumentException( "RoomType doesn't exists" );
        }

        return roomType;
    }

    public List<RoomType> GetAllById( int propertyId )
    {
        return GetAll().Where( r => r.PropertyId == propertyId ).ToList();
    }

    public List<RoomType> GetAll()
    {
        return _roomTypeRepository.GetAll();
    }

    public void Update( RoomType roomType )
    {
        ValidateRoomType( roomType );

        _roomTypeRepository.Update( roomType );

        _unitOfWork.CommitAsync();
    }

    private void ValidateRoomType( RoomType roomType )
    {
        ValidatePropertyId( roomType.PropertyId );
        ValidateName( roomType.Name );
        ValidateDailyPrice( roomType.DailyPrice );
        ValidateCurrency( roomType.Currency );
        ValidatePersonCounts( roomType.MinPersonCount, roomType.MaxPersonCount );
        ValidateServices( roomType.Services );
        ValidateAmenities( roomType.Amenities );
    }

    private void CheckRoomTypeExists( int id )
    {
        bool isExists = _roomTypeRepository.GetById( id ) is not null;
        if ( isExists )
        {
            throw new ArgumentException( "RoomType already exists" );
        }
    }

    private void ValidatePropertyId( int propertyId )
    {
        if ( propertyId <= 0 )
        {
            throw new ArgumentException( "PropertyId must be greater than 0" );
        }
    }

    private void ValidateName( string name )
    {
        if ( string.IsNullOrWhiteSpace( name ) )
        {
            throw new ArgumentException( "Name cannot be empty or whitespace" );
        }
        if ( name.Length > 100 )
        {
            throw new ArgumentException( "Name cannot be longer than 100 characters" );
        }
    }

    private void ValidateDailyPrice( decimal dailyPrice )
    {
        if ( dailyPrice <= 0 )
        {
            throw new ArgumentException( "DailyPrice must be greater than 0" );
        }
        if ( dailyPrice > 100000000 )
        {
            throw new ArgumentException( "DailyPrice is too high" );
        }
    }

    private void ValidateCurrency( string currency )
    {
        if ( string.IsNullOrWhiteSpace( currency ) )
        {
            throw new ArgumentException( "Currency cannot be empty" );
        }
        if ( currency.Length != 3 )
        {
            throw new ArgumentException( "Currency must be a 3-letter code" );
        }
    }

    private void ValidatePersonCounts( int minCount, int maxCount )
    {
        if ( minCount <= 0 )
        {
            throw new ArgumentException( "Minimal person count could not be less than 1" );
        }
        if ( maxCount <= 0 )
        {
            throw new ArgumentException( "Maximal person count could not be less than 1" );
        }
        if ( maxCount < minCount )
        {
            throw new ArgumentException( "Maximal person count cannot be less than minimal" );
        }
    }

    private void ValidateServices( List<string> services )
    {
        if ( services is null )
        {
            throw new ArgumentException( "Services list cannot be null" );
        }
        if ( services.Any( string.IsNullOrWhiteSpace ) )
        {
            throw new ArgumentException( "Services cannot contain empty or whitespace values" );
        }
    }

    private void ValidateAmenities( List<string> amenities )
    {
        if ( amenities is null )
        {
            throw new ArgumentException( "Amenities list cannot be null" );
        }
        if ( amenities.Any( string.IsNullOrWhiteSpace ) )
        {
            throw new ArgumentException( "Amenities cannot contain empty or whitespace values" );
        }
    }
}