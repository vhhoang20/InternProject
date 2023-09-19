using InternProject.Database;
using InternProject.Database.Model;
using InternProject.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public class EmployeeRepository: IEmployeeRepository, IDisposable
{
    private APIDbContext context;

    public EmployeeRepository(APIDbContext context)
    {
        this.context = context;
    }

    public IEnumerable<employees> GetAll()
    {
        return context.Employees.ToList();
    }

    public employees GetByID(int id)
    {
        return context.Employees.Find(id);
    }

    public void Insert(employees student)
    {
        context.Employees.Add(student);
    }

    public void Delete(int studentID)
    {
        employees student = context.Employees.Find(studentID);
        context.Employees.Remove(student);
    }

    public void Update(employees student)
    {
        context.Entry(student).State = EntityState.Modified;
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