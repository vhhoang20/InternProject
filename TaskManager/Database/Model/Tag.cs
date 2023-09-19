using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task_Manager.Database.Model
{
    public class Tag
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
    }
}
