using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace g13lec6.Models
{
    public partial class group13Context : DbContext
    {
        public group13Context()
        {
        }

        public group13Context(DbContextOptions<group13Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Dept> Depts { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=group13;Trusted_Connection = yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DeptId)
                    .HasConstraintName("Emp_Dept_Fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
