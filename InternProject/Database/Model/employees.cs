using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternProject.Database.Model
{
    public class employees
    {
        [Key]
        public int employee_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string? phone_number { get; set; }
        public DateOnly hire_date { get; set; }

        [ForeignKey("job")]
        public int job_id { get; set; }
        public decimal salary { get; set; }
        [ForeignKey("employee_id")]
        public int? manager_id { get; set; }
        [ForeignKey("department")]
        public int? department_id { get; set; }
    }
}