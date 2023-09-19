using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternProject.Database.Model
{
    public class dependents
    {
        [Key]
        public int dependent_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string relationship { get; set; }
        [ForeignKey("employee")]
        public int employee_id { get; set; }
        public employees employee { get; set; }
    }
}
