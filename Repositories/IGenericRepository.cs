﻿namespace Laboratorio04_Lupo.Repositories;

public interface IGenericRepository<T> where T : class
{
    
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(int id);
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(int id);
}