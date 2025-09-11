﻿using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Repositories;

namespace WebApi.Infrastructure.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly DbSet<TEntity> _entities;

    public BaseRepository( WebApiDbContext webApiDbContext )
    {
        _entities = webApiDbContext.Set<TEntity>();
    }

    public async Task CreateAsync( TEntity entity )
    {
        await _entities.AddAsync( entity );
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _entities.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync( int id )
    {
        return await _entities.FindAsync( id );
    }

    public void Update( TEntity entity )
    {
        _entities.Update( entity );
    }

    public void Delete( TEntity entity )
    {
        _entities.Remove( entity );
    }
}