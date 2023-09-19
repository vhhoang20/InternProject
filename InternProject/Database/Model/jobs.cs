using System.ComponentModel.DataAnnotations;

namespace InternProject.Database.Model
{
    public class jobs
    {
        [Key]
        public int job_id { get; set; }
        public string job_title { get; set; }
        public decimal? min_salary { get; set; }
        public decimal? max_salary { get; set; }
    }
}
