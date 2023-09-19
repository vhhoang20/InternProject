using InternProject.Database;
using InternProject.Database.Model;
using InternProject.Interface;
using Microsoft.EntityFrameworkCore;

namespace InternProject.Repository
{
    public class UnitOfWork : IDisposable
    {
        private APIDbContext context;
        private GenericRepository<employees> employeeRepository;

        public UnitOfWork(DbContextOptions<APIDbContext> options)
        {
            context = new APIDbContext(options);
        }

        public GenericRepository<employees> EmployeeRepository
        {
            get
            {

                if (this.employeeRepository == null)
                {
                    this.employeeRepository = new GenericRepository<employees>(context);
                }
                return employeeRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
