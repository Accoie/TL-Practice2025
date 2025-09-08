using WebApi.Domain.Entities;

namespace WebApi.Domain.Services.Interfaces;

public interface IPropertyService
{
    public Task CreateOrUpdate( Property property );

    public Task<List<Property>> GetAll();
    public Task<Property> GetById( int id );

    public Task Delete( int id );
}