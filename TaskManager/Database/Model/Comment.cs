using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task_Manager.Database.Model
{
    public class Comment
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("Task")]
        public long TaskId { get; set; }
        [ForeignKey("Activity")]
        public long? ActivityId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Content { get; set; }

        public Task Task { get; set; }
        public Activity Activity { get; set; }
    }
}
