using WebApi.Domain.Entities;
using WebApi.Domain.Foundations;
using WebApi.Domain.Repositories;
using WebApi.Domain.Services.Interfaces;

namespace WebApi.Domain.Services;

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
        ValidateProperty( property );
        CheckPropertyExists( property.Id );

        _propertyRepository.Create( property );
        _unitOfWork.CommitAsync();
    }

    public Property GetById( int id )
    {
        Property? property = _propertyRepository.GetById( id );

        if ( property is null )
        {
            throw new ArgumentException( "Property doesn't exists" );
        }

        return property;
    }

    public List<Property> GetAll()
    {
        return _propertyRepository.GetAll();
    }

    public void Update( Property property )
    {
        _propertyRepository.Update( property );

        _unitOfWork.CommitAsync();
    }

    private void ValidateProperty( Property property )
    {
        ValidateName( property.Name );
        ValidateCountry( property.Country );
        ValidateCity( property.City );
        ValidateAddress( property.Address );
        ValidateCoordinates( property.Latitude, property.Longitude );
    }

    private void CheckPropertyExists( int id )
    {
        bool isExists = _propertyRepository.GetById( id ) is not null;
        if ( isExists )
        {
            throw new ArgumentException( "Property already exists" );
        }
    }

    private void ValidateName( string name )
    {
        if ( string.IsNullOrWhiteSpace( name ) )
        {
            throw new ArgumentException( "Property name cannot be empty" );
        }

        if ( name.Length > 100 )
        {
            throw new ArgumentException( "Property name cannot exceed 100 characters" );
        }
    }

    private void ValidateCountry( string country )
    {
        if ( string.IsNullOrWhiteSpace( country ) )
        {
            throw new ArgumentException( "Country cannot be empty" );
        }

        if ( country.Length > 50 )
        {
            throw new ArgumentException( "Country name cannot exceed 50 characters" );
        }
    }

    private void ValidateCity( string city )
    {
        if ( string.IsNullOrWhiteSpace( city ) )
        {
            throw new ArgumentException( "City cannot be empty" );
        }

        if ( city.Length > 50 )
        {
            throw new ArgumentException( "City name cannot exceed 50 characters" );
        }
    }

    private void ValidateAddress( string address )
    {
        if ( string.IsNullOrWhiteSpace( address ) )
        {
            throw new ArgumentException( "Address cannot be empty" );
        }

        if ( address.Length > 200 )
        {
            throw new ArgumentException( "Address cannot exceed 200 characters" );
        }
    }

    private void ValidateCoordinates( decimal latitude, decimal longitude )
    {
        if ( latitude < -90 || latitude > 90 )
        {
            throw new ArgumentException( "Latitude must be between -90 and 90 degrees" );
        }

        if ( longitude < -180 || longitude > 180 )
        {
            throw new ArgumentException( "Longitude must be between -180 and 180 degrees" );
        }
    }

    public void Delete( int id )
    {
        Property property = GetById( id );

        _propertyRepository.Delete( property );

        _unitOfWork.CommitAsync();
    }
}