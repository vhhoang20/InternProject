using System.ComponentModel.DataAnnotations;

namespace InternProject.Database.Model
{
    public class regions
    {
        [Key]
        public int region_id { get; set; }
        public string region_name { get; set; }
    }
}
