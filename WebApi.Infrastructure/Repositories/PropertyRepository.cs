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

    public List<Property> List()
    {
        return _webApiDbContext.Properties.ToList();
    }
    public async Task<Property?> GetById( int id )
    {
        return await _webApiDbContext.FindAsync<Property>( id );
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