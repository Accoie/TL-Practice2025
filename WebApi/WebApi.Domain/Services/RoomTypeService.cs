using FluentValidation;
using WebApi.Domain.Entities;
using WebApi.Domain.Foundations;
using WebApi.Domain.Repositories;
using WebApi.Domain.Services.Interfaces;

namespace WebApi.Domain.Services;

public class RoomTypeService : IRoomTypeService
{
    private readonly IRoomTypeRepository _roomTypeRepository;
    private readonly IPropertyService _propertyService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<RoomType> _validator;

    public RoomTypeService( IRoomTypeRepository roomTypeRepository,
                            IPropertyService propertyService,   
                            IUnitOfWork unitOfWork,
                            IValidator<RoomType> validator )
    {
        _roomTypeRepository = roomTypeRepository;
        _propertyService = propertyService;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task CreateOrUpdate( RoomType roomType )
    {
        await _propertyService.GetById( roomType.PropertyId );

        RoomType? existingRoomType = await _roomTypeRepository.GetByIdAsync( roomType.Id );

        if ( existingRoomType is null )
        {
            await _validator.ValidateAndThrowAsync( roomType );
            await _roomTypeRepository.CreateAsync( roomType );
        }
        else
        {
            existingRoomType.Update( roomType );
            await _validator.ValidateAndThrowAsync( existingRoomType );
            _roomTypeRepository.Update( existingRoomType );
        }

        await _unitOfWork.CommitAsync();
    }

    public async Task Delete( int id )
    {
        RoomType roomType = await GetById( id );

        _roomTypeRepository.Delete( roomType );

        await _unitOfWork.CommitAsync();
    }

    public async Task<RoomType> GetById( int id )
    {
        RoomType? roomType = await _roomTypeRepository.GetByIdAsync( id );

        if ( roomType is null )
        {
            throw new ArgumentException( "RoomType doesn't exists" );
        }

        return roomType;
    }

    public async Task<List<RoomType>> GetAllById( int propertyId )
    {
        List<RoomType> roomTypes = await GetAll();

        return roomTypes.Where( r => r.PropertyId == propertyId ).ToList();
    }

    public async Task<List<RoomType>> GetAll()
    {
        return await _roomTypeRepository.GetAllAsync();
    }
}