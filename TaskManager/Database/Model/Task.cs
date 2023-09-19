using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task_Manager.Database.Model
{
    public class Task
    {
        [Key]
        public long Id { get; set; }
        public long UserId { get; set; }
        public long CreatedBy { get; set; }
        public long UpdatedBy { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public short Status { get; set; }
        public float Hours { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? PlannedStartDate { get; set; }
        public DateTime? PlannedEndDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public string Content { get; set; }


        [ForeignKey("CreatedBy")]
        public User CreatedByUser { get; set; }

        [ForeignKey("UpdatedBy")]
        public User UpdatedByUser { get; set; }

        [ForeignKey("UserId")]
        public User UserIdUser { get; set; }
    }
}
