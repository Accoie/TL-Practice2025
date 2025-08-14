using WebApi.Domain.Entities;
using WebApi.Domain.Foundations;
using WebApi.Domain.Repositories;
using WebApi.Domain.Services;

namespace WebApi.Infrastructure.Services;

public class PropertyService : IPropertyService
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PropertyService( IPropertyRepository propertyRepository, IUnitOfWork unitOfWork )
    {
        _propertyRepository = propertyRepository;
        _unitOfWork = unitOfWork;
    }

    public void Create( Property property )
    {
        bool isExists = _propertyRepository.GetById( property.Id ).Result != null;

        if ( isExists )
        {
            throw new ArgumentException( "Property is already exists" );
        }

        _propertyRepository.Create( property );

        _unitOfWork.CommitAsync();
    }

    public void Delete( int id )
    {
        Property property = GetById( id );

        _propertyRepository.Delete( property );

        _unitOfWork.CommitAsync();
    }

    public Property GetById( int id )
    {
        Property? property = _propertyRepository.GetById( id ).Result;

        if ( property == null )
        {
            throw new ArgumentException( "Property doesn't exists" );
        }

        return property;
    }

    public List<Property> GetList()
    {
        return _propertyRepository.List();
    }

    public void Update( Property property )
    {
        Property oldProperty = GetById( property.Id );

        oldProperty.Longitude = property.Longitude;
        oldProperty.Latitude = property.Latitude;
        oldProperty.Address = property.Address;
        oldProperty.City = property.City;
        oldProperty.Country = property.Country;
        oldProperty.Name = property.Name;   

        _propertyRepository.Update( oldProperty );

        _unitOfWork.CommitAsync();
    }
}
