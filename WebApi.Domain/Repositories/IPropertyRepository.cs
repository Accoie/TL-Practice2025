using WebApi.Domain.Entities;

namespace WebApi.Domain.Repositories;

public interface IPropertyRepository
{
    public void Create( Property property );

    public List<Property> List();
    public Task<Property?> GetById( int id );

    public void Update( Property property );

    public void Delete( Property property );
}
