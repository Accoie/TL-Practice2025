using WebApi.Domain.Entities;

namespace WebApi.Domain.Services.Interfaces;

public interface IPropertyService
{
    public Task Create( Property property );

    public Task<List<Property>> GetAll();
    public Task<Property> GetById( int id );

    public Task Update( int id, Action<Property> updateAction );

    public Task Delete( int id );
}