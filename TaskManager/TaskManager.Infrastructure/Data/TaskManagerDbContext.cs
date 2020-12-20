using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.Core.Entities;

namespace TaskManager.Infrastructure.Data
{
    public class TaskManagerDbContext : DbContext
    {
        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public DbSet<TaskHistory> TaskHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Task>(ConfigureTask);
            modelBuilder.Entity<TaskHistory>(ConfigureTaskHistory);
        }

        private void ConfigureUser(EntityTypeBuilder<User> builder) {
            //Fluent API:
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email).HasMaxLength(50);
            builder.Property(u => u.Password).HasMaxLength(10);
            builder.Property(u => u.Fullname).HasMaxLength(50);
            builder.Property(u => u.Mobileno).HasMaxLength(50);
        }
        private void ConfigureTask(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("Tasks");
            builder.HasKey(t => t.Id);
            builder.Property(t=> t.UserId);
            builder.Property(t => t.Title).HasMaxLength(50);
            builder.Property(t => t.Description).HasMaxLength(500);
            builder.Property(t => t.DueDate);
            builder.Property(t => t.Priority).HasMaxLength(1);
            builder.Property(t => t.Remarks).HasMaxLength(500);
        }
        private void ConfigureTaskHistory(EntityTypeBuilder<TaskHistory> builder)
        {
            builder.ToTable("TaskHistories");
            builder.HasKey(t => t.TaskId);
            builder.Property(t => t.UserId);
            builder.Property(t => t.Title).HasMaxLength(50);
            builder.Property(t => t.Description).HasMaxLength(500);
            builder.Property(t => t.UserId);
            builder.Property(t => t.DueDate);
            builder.Property(t => t.Completed);
            builder.Property(t => t.Remarks).HasMaxLength(500);

        }
    }
}
