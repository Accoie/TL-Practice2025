using FluentValidation;
using WebApi.Domain.Entities;
using WebApi.Domain.Foundations;
using WebApi.Domain.Repositories;
using WebApi.Domain.Services.Interfaces;

namespace WebApi.Domain.Services;

public class PropertyService : IPropertyService
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<Property> _validator;

    public PropertyService( IPropertyRepository propertyRepository, 
                            IUnitOfWork unitOfWork, 
                            IValidator<Property> validator )
    {
        _propertyRepository = propertyRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task Create( Property property )
    {
        if ( await _propertyRepository.GetByIdAsync( property.Id ) is not null )
        {
            throw new ArgumentException( "Property already exists" );
        }

        await _validator.ValidateAndThrowAsync( property );

        await _propertyRepository.CreateAsync( property );
        await _unitOfWork.CommitAsync();
    }

    public async Task<List<Property>> GetAll()
    {
        return await _propertyRepository.GetAllAsync();
    }

    public async Task<Property> GetById( int id )
    {
        Property? property = await _propertyRepository.GetByIdAsync( id );

        if ( property is null )
        {
            throw new ArgumentException( "Property doesn't exist" );
        }

        return property;
    }

    public async Task Update( int id , Action<Property> updateAction )
    {
        Property existingProperty = await GetById( id );

        updateAction( existingProperty );

        await _validator.ValidateAndThrowAsync( existingProperty );

        _propertyRepository.Update( existingProperty );
        await _unitOfWork.CommitAsync();
    }

    public async Task Delete( int id )
    {
        Property property = await GetById( id );

        _propertyRepository.Delete( property );
        await _unitOfWork.CommitAsync();
    }
}