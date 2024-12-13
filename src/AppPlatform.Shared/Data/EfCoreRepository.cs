﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AppPlatform.Shared.Data;
public class EfCoreRepository<T> : IRepository<T> where T : class
{
    protected readonly IDbContextFactory<ApplicationDbContext> dbContextFactory;

    public EfCoreRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        dbContextFactory = contextFactory;
    }

    public virtual async Task<T?> GetByIdAsync(string id)
    {
        using var context = dbContextFactory.CreateDbContext();
        return await context.Set<T>().FindAsync(id);
    }
    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        using var context = dbContextFactory.CreateDbContext();
        return await context.Set<T>().ToListAsync();
    }
    public virtual async Task UpsertAsync(T entity)
    {
        using var context = dbContextFactory.CreateDbContext();
        var dbSet = context.Set<T>();
        var existingEntity = await dbSet.FindAsync(entity);
        if (existingEntity == null)
        {
            dbSet.Add(entity);
        }
        else
        {
            context.Entry(existingEntity).CurrentValues.SetValues(entity);
        }
        await context.SaveChangesAsync();
    }
    public virtual async Task DeleteAsync(string id)
    {
        using var context = dbContextFactory.CreateDbContext();
        var entity = await context.Set<T>().FindAsync(id);
        if (entity != null)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}