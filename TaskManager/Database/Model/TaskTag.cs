using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task_Manager.Database.Model
{
    public class TaskTag
    {
        [Key]
        public long TaskId { get; set; }
        [Key]
        public long TagId { get; set; }

        [ForeignKey("TaskId")]
        public Task Task { get; set; }

        [ForeignKey("TagId")]
        public Tag Tag { get; set; }
    }
}
