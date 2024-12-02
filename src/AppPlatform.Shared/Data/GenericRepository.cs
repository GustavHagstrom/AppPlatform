using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace AppPlatform.Shared.Data;
public class GenericRepository<TEntity> where TEntity : class
{
    protected readonly IDbContextFactory<ApplicationDbContext> dbContextFactory;

    public GenericRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        dbContextFactory = contextFactory;
    }

    public async Task<TEntity?> GetByIdAsync(object id)
    {
        using var context = dbContextFactory.CreateDbContext();
        return await context.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        using var context = dbContextFactory.CreateDbContext();
        return await context.Set<TEntity>().ToListAsync();
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        using var context = dbContextFactory.CreateDbContext();
        context.Set<TEntity>().Add(entity);
        await context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        using var context = dbContextFactory.CreateDbContext();
        context.Set<TEntity>().Attach(entity);
        context.Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }
    public virtual async Task UpsertAsync(TEntity entity)
    {
        using var context = dbContextFactory.CreateDbContext();
        var dbSet = context.Set<TEntity>();
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

    public virtual async Task DeleteAsync(object id)
    {
        using var context = dbContextFactory.CreateDbContext();
        var entity = await context.Set<TEntity>().FindAsync(id);
        if (entity != null)
        {
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }
    }

    
}