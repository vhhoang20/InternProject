using InternProject.Database;
using InternProject.Database.Model;
using InternProject.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

public class GenericRepository<T> where T : class
{
    internal APIDbContext _context;
    internal DbSet<T> _dbSet;
    public GenericRepository(APIDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }
    public int Count()
    {
        return _dbSet.Count();
    }
    public void Delete(object id)
    {
        T entityToDelete = _dbSet.Find(id);

        if (_context.Entry(entityToDelete).State == EntityState.Detached)
        {
            _dbSet.Attach(entityToDelete);
        }
        _dbSet.Remove(entityToDelete);
    }
    public T GetById(object id)
    {
        var item = _dbSet.Find(id);
        return item;
    }
    public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
    {
        IQueryable<T> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return orderBy(query).ToList();
        }
        else
        {
            return query.ToList();
        }
    }
    public void Update(T entity)
    {
        var existingEntity = _dbSet.Find(GetPrimaryKeyValue(entity));
        if (existingEntity != null)
        {
            _dbSet.Entry(existingEntity).CurrentValues.SetValues(entity);
        }
    }

    public object GetPrimaryKeyValue(T entity)
    {
        var entityType = typeof(T);
        var keyProperty = entityType.GetProperties()
            .FirstOrDefault(prop => prop.GetCustomAttribute<KeyAttribute>() != null);

        if (keyProperty == null)
        {
            throw new InvalidOperationException("The entity does not have a primary key defined.");
        }

        return keyProperty.GetValue(entity);
    }
}