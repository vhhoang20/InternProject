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

        public DbSet<Activity> Activity { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Model.Task> Task { get; set; }
        public DbSet<TaskTag> TaskTag { get; set; }
        public DbSet<TaskMeta> TaskMeta { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Model.Task>()
                .HasOne(t => t.CreatedByUser)
                .WithMany()
                .HasForeignKey(t => t.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Model.Task>()
                .HasOne(t => t.UpdatedByUser)
                .WithMany()
                .HasForeignKey(t => t.UpdatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Model.Task>()
                .HasOne(t => t.UserIdUser)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Activity>()
                .HasOne(a => a.CreatedByUser)
                .WithMany()
                .HasForeignKey(a => a.CreatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Activity>()
                .HasOne(a => a.UpdatedByUser)
                .WithMany()
                .HasForeignKey(a => a.UpdatedBy)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Activity>()
                .HasOne(a => a.UserIdUser)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Activity>()
                .HasOne(a => a.Task)
                .WithMany()
                .HasForeignKey(a => a.TaskId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique()
                .HasDatabaseName("uq_username");

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Mobile)
                .IsUnique()
                .HasDatabaseName("uq_mobile");

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique()
                .HasDatabaseName("uq_email");

            modelBuilder.Entity<Model.Task>()
                .HasIndex(t => t.UserId)
                .HasDatabaseName("idx_task_user");

            modelBuilder.Entity<Model.Task>()
                .HasIndex(t => t.CreatedBy)
                .HasDatabaseName("idx_task_creator");

            modelBuilder.Entity<Model.Task>()
                .HasIndex(t => t.UpdatedBy)
                .HasDatabaseName("idx_task_modifier");

            modelBuilder.Entity<TaskMeta>()
                .HasIndex(tm => tm.TaskId)
                .HasDatabaseName("idx_meta_task");

            modelBuilder.Entity<TaskMeta>()
                .HasIndex(tm => new { tm.TaskId, tm.Key })
                .IsUnique()
                .HasDatabaseName("uq_task_meta");

            modelBuilder.Entity<TaskTag>()
                .HasKey(tt => new { tt.TaskId, tt.TagId });

            modelBuilder.Entity<TaskTag>()
                .HasIndex(tt => tt.TaskId)
                .HasDatabaseName("idx_tt_task");

            modelBuilder.Entity<TaskTag>()
                .HasIndex(tt => tt.TagId)
                .HasDatabaseName("idx_tt_tag");

            modelBuilder.Entity<Activity>()
                .HasIndex(a => a.UserId)
                .HasDatabaseName("idx_activity_user");

            modelBuilder.Entity<Activity>()
                .HasIndex(a => a.TaskId)
                .HasDatabaseName("idx_activity_task");

            modelBuilder.Entity<Activity>()
                .HasIndex(a => a.CreatedBy)
                .HasDatabaseName("idx_activity_creator");

            modelBuilder.Entity<Activity>()
                .HasIndex(a => a.UpdatedBy)
                .HasDatabaseName("idx_activity_modifier");

            modelBuilder.Entity<Comment>()
                .HasIndex(c => c.TaskId)
                .HasDatabaseName("idx_comment_task"); 

            modelBuilder.Entity<Comment>()
                .HasIndex(c => c.ActivityId)
                .HasDatabaseName("idx_comment_activity");
        }
    }
}
