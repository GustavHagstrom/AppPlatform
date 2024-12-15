﻿namespace AppPlatform.Shared.Data;
public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(string id);
    Task UpsertAsync(T entity);
    Task DeleteAsync(string id);
}