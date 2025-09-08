using FluentValidation;
using WebApi.Domain.Entities;
using WebApi.Domain.Foundations;
using WebApi.Domain.Repositories;
using WebApi.Domain.Services.Interfaces;

namespace WebApi.Domain.Services;

public class RoomTypeService : IRoomTypeService
{
    private readonly IRoomTypeRepository _roomTypeRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<RoomType> _validator;

    public RoomTypeService( IRoomTypeRepository roomTypeRepository, IUnitOfWork unitOfWork, IValidator<RoomType> validator )
    {
        _roomTypeRepository = roomTypeRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task Create( RoomType roomType )
    {
        bool isRoomTypeExists = await _roomTypeRepository.GetByIdAsync( roomType.Id ) is not null;

        if ( isRoomTypeExists )
        {
            throw new ArgumentException( "RoomType already exists" );
        }

        await _validator.ValidateAndThrowAsync( roomType );

        await _roomTypeRepository.CreateAsync( roomType );

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

    public async Task Update( int id, Action<RoomType> updateAction )
    {
        RoomType existingRoomType = await GetById( id );

        updateAction( existingRoomType );

        await _validator.ValidateAndThrowAsync( existingRoomType );

        _roomTypeRepository.Update( existingRoomType );

        await _unitOfWork.CommitAsync();
    }
}