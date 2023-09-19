﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Task_Manager.Database.Model
{
    public class TaskMeta
    {
        [Key]
        public long Id { get; set; }
        public long TaskId { get; set; }
        public string Key { get; set; }
        public string Content { get; set; }

        [ForeignKey("TaskId")]
        public Task Task { get; set; }
    }
}
