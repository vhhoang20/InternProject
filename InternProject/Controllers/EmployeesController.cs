using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternProject.Database;
using InternProject.Database.Model;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using InternProject.Interface;
using InternProject.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace InternProject.Controllers
{
    [ApiController]
    public class EmployeesController : ODataController
    {
        private UnitOfWork unitOfWork;

        public EmployeesController(DbContextOptions<APIDbContext> dbContextOptions)
        {
            unitOfWork = new UnitOfWork(dbContextOptions);
        }

        [HttpGet("Employees/get")]
        public IActionResult GetEmployees()
        {
            var employeeList = unitOfWork.EmployeeRepository.GetAll();
            return Ok(employeeList.ToList());
        }

        [HttpGet("Employees/get/{id}")]
        [HttpGet("odata/Employees/{id}")]
        public IActionResult GetEmployee(int id)
        {
            var entity = unitOfWork.EmployeeRepository.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpGet("export/excel")]
        public IActionResult ExportEmployeesToExcel()
        {
            var employees = unitOfWork.EmployeeRepository.GetAll().ToList();

            if (employees.Count == 0)
            {
                return NotFound("No employees found for export.");
            }

            // Create a new Excel package and worksheet
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("EmployeeList");

                // Define the header row
                worksheet.Cells[1, 1].Value = "Employee ID";
                worksheet.Cells[1, 2].Value = "First Name";
                worksheet.Cells[1, 3].Value = "Last Name";
                worksheet.Cells[1, 4].Value = "Email";
                worksheet.Cells[1, 5].Value = "Phone Number";
                worksheet.Cells[1, 6].Value = "Hire Date";
                worksheet.Cells[1, 7].Value = "Job ID";
                worksheet.Cells[1, 8].Value = "Salary";
                worksheet.Cells[1, 9].Value = "Manager ID";
                worksheet.Cells[1, 10].Value = "Department ID";
                // Add more columns as needed

                // Populate the data rows
                for (int i = 0; i < employees.Count; i++)
                {
                    var employee = employees[i];
                    worksheet.Cells[i + 2, 1].Value = employee.employee_id;
                    worksheet.Cells[i + 2, 2].Value = employee.first_name;
                    worksheet.Cells[i + 2, 3].Value = employee.last_name;
                    worksheet.Cells[i + 2, 4].Value = employee.email;
                    worksheet.Cells[i + 2, 5].Value = employee.phone_number ?? null; // Handle null phone numbers
                    worksheet.Cells[i + 2, 6].Value = employee.hire_date.ToString("yyyy-MM-dd"); ;
                    worksheet.Cells[i + 2, 7].Value = employee.job_id;
                    worksheet.Cells[i + 2, 8].Value = employee.salary;
                    worksheet.Cells[i + 2, 9].Value = employee.manager_id ?? null; // Set empty string for manager_id if it's 0
                    worksheet.Cells[i + 2, 10].Value = employee.department_id ?? null; // Set empty string for department_id if it's 0
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                // Set the horizontal alignment for the entire worksheet to center
                worksheet.Cells[worksheet.Dimension.Address].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // Set the vertical alignment for the entire worksheet to center
                worksheet.Cells[worksheet.Dimension.Address].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                // Save the Excel package to a stream
                var stream = new MemoryStream(package.GetAsByteArray());

                // Return the Excel file as a FileStreamResult
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "EmployeeList.xlsx");
            }
        }

        [HttpPut("Employees/update/{id}")]
        public IActionResult UpdateEmployee(int id, employees employ)
        {
            if (employ == null || employ.employee_id != id)
            {
                return BadRequest();
            }
            unitOfWork.EmployeeRepository.Update(employ);
            unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete("Employees/delete/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            unitOfWork.EmployeeRepository.Delete(id);
            unitOfWork.Save();
            return NoContent();
        }
    }
}
