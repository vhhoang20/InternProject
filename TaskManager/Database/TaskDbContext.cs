using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using Microsoft.EntityFrameworkCore;
using Task_Manager.Database.Model;

namespace Task_Manager.Database
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        { }

        public DbSet<Activity> Regions { get; set; }
        public DbSet<Comment> Countries { get; set; }
        public DbSet<Tag> Locations { get; set; }
        public DbSet<Model.Task> Jobs { get; set; }
        public DbSet<TaskTag> Departments { get; set; }
        public DbSet<TaskMeta> Employees { get; set; }
        public DbSet<User> Dependents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique()
            .HasName("uq_username");

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Mobile)
                .IsUnique()
                .HasName("uq_mobile");

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique()
                .HasName("uq_email");

            modelBuilder.Entity<Model.Task>()
                .HasIndex(t => t.UserId)
                .HasName("idx_task_user");

            // Define index for the "createdBy" column
            modelBuilder.Entity<Model.Task>()
                .HasIndex(t => t.CreatedBy)
                .HasName("idx_task_creator");

            // Define index for the "updatedBy" column
            modelBuilder.Entity<Model.Task>()
                .HasIndex(t => t.UpdatedBy)
                .HasName("idx_task_modifier");

            // Define index for the "taskId" column
            modelBuilder.Entity<TaskMeta>()
                .HasIndex(tm => tm.TaskId)
                .HasName("idx_meta_task");

            // Define unique constraint for the combination of "taskId" and "key" columns
            modelBuilder.Entity<TaskMeta>()
                .HasIndex(tm => new { tm.TaskId, tm.Key })
                .IsUnique()
                .HasName("uq_task_meta");

            modelBuilder.Entity<TaskTag>()
            .HasIndex(tt => tt.TaskId)
            .HasName("idx_tt_task");

            // Define index for the "tagId" column
            modelBuilder.Entity<TaskTag>()
                .HasIndex(tt => tt.TagId)
                .HasName("idx_tt_tag");

            modelBuilder.Entity<Activity>()
            .HasIndex(a => a.UserId)
            .HasName("idx_activity_user");

            // Define index for the "taskId" column
            modelBuilder.Entity<Activity>()
                .HasIndex(a => a.TaskId)
                .HasName("idx_activity_task");

            // Define index for the "createdBy" column
            modelBuilder.Entity<Activity>()
                .HasIndex(a => a.CreatedBy)
                .HasName("idx_activity_creator");

            // Define index for the "updatedBy" column
            modelBuilder.Entity<Activity>()
                .HasIndex(a => a.UpdatedBy)
                .HasName("idx_activity_modifier");

            modelBuilder.Entity<Comment>()
            .HasIndex(c => c.TaskId)
            .HasName("idx_comment_task"); 

            // Define index for the "activityId" column
            modelBuilder.Entity<Comment>()
                .HasIndex(c => c.ActivityId)
                .HasName("idx_comment_activity");
        }
    }
}
