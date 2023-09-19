using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternProject.Database.Model
{
    public class countries
    {
        [Key]
        public string country_id { get; set; }
        public string country_name { get; set; }
        [ForeignKey("region")]
        public int region_id { get; set; }
        public regions region { get; set; }
    }
}
