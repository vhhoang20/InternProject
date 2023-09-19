using InternProject.Database.Model;
using System.Collections.Generic;

namespace InternProject.Interface
{
    public interface IGenericRepository<T>
    {
        T GetById(object id);
        IEnumerable<T> GetAll();
        void Delete(object id);
        void Update(T entity);
    }
}
