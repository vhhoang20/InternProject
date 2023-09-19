using InternProject.Database.Model;

namespace InternProject.Interface
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employee{ get; }

        int Save();
    }
}
