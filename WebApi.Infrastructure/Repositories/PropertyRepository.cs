using WebApi.Domain.Entities;
using WebApi.Domain.Repositories;

namespace WebApi.Infrastructure.Repositories;

public class PropertyRepository : IPropertyRepository
{
    private readonly WebApiDbContext _webApiDbContext;

    public PropertyRepository( WebApiDbContext webApiDbContext )
    {
        _webApiDbContext = webApiDbContext;
    }

    public void Create( Property property )
    {
        _webApiDbContext.Add( property );
    }

    public List<Property> GetAll()
    {
        return _webApiDbContext.Properties.ToList();
    }

    public Property? GetById( int id )
    {
        return _webApiDbContext.Find<Property>( id );
    }

    public void Update( Property property )
    {
        _webApiDbContext.Properties.Update( property );
    }

    public void Delete( Property property )
    {
        _webApiDbContext.Properties.Remove( property );
    }
}