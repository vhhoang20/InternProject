using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Task_Manager.Database.Model
{
    public class TaskTag
    {
        [Key]
        [ForeignKey("Task")]
        public long TaskId { get; set; }

        [Key]
        [ForeignKey("Tag")]
        public long TagId { get; set; }

        public Task Task { get; set; }
        public Tag Tag { get; set; }
    }
}
