using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task_Manager.Database.Model
{
    public class Comment
    {
        [Key]
        public long Id { get; set; }
        public long TaskId { get; set; }
        public long? ActivityId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Content { get; set; }

        [ForeignKey("TaskId")]
        public Task Task { get; set; }

        [ForeignKey("ActivityId")]
        public Activity Activity { get; set; }
    }
}
