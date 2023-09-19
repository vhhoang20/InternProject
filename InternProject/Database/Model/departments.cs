using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternProject.Database.Model
{
    public class departments
    {
        [Key]
        public int department_id { get; set; }
        public string department_name { get; set; }
        [ForeignKey("location")]
        public int? location_id { get; set; }
        public locations location { get; set; }
    }
}
