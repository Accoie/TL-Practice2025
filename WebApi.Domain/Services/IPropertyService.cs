using WebApi.Domain.Entities;

namespace WebApi.Domain.Services;

public interface IPropertyService
{
    public void Create( Property property );

    public List<Property> GetList();
    public Property GetById( int id );

    public void Update( Property property );

    public void Delete( int id );
}