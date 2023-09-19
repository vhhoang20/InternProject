using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternProject.Database.Model
{
    public class locations
    {
        [Key]
        public int location_id { get; set; }
        public string street_address { get; set; }
        public string? postal_code { get; set; }
        public string city { get; set; }
        public string? state_province { get; set; }
        [ForeignKey("country")]
        public string country_id { get; set; }
        public countries country { get; set; }
    }
}
