using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CompanyAppAPI.Models;

#nullable disable

namespace CompanyAppAPI.Context
{
    public partial class CompanyContext : DbContext
    {
        public CompanyContext()
        {
        }

        public CompanyContext(DbContextOptions<CompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=CompanyDbConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DpId)
                    .HasName("PK__Departme__7AF91DCF5896C737");

                entity.ToTable("Department");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmId)
                    .HasName("PK__Employee__DCB5BE22D80EA8F1");

                entity.ToTable("Employee");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("decimal(16, 2)");

                entity.HasOne(d => d.Dp)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DpId)
                    .HasConstraintName("FK__Employee__DpId__38996AB5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
