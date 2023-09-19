using InternProject.Database.Model;
using System.Collections.Generic;

namespace InternProject.Interface
{
    public interface IEmployeeRepository: IDisposable
    {
        IEnumerable<employees> GetAll();
        employees GetByID(int Id);
        void Insert(employees employee);
        void Delete(int ID);
        void Update(employees student);
        void Save();
    }
}
