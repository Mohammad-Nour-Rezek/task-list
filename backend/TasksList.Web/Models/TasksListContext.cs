using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TasksList.Web.Models
{
    public partial class TasksListContext : DbContext
    {
        public TasksListContext()
        {
        }

        public TasksListContext(DbContextOptions<TasksListContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TaskList> TaskLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MOHAMMADNOUR\\SQLEXPRESS01;Database=TasksList;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TaskList>(entity =>
            {
                entity.ToTable("TaskList");

                entity.Property(e => e.Day).HasColumnType("datetime");

                entity.Property(e => e.Text).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
