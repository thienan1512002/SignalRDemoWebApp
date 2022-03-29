using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SignalRDemoWebApp.Models
{
    public partial class SignalRDemoContext : DbContext
    {
        public SignalRDemoContext()
        {
        }

        public SignalRDemoContext(DbContextOptions<SignalRDemoContext> options)
            : base(options)
        {
        }

      
        public virtual DbSet<Notyf> Notyfs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=.;Database=SignalRDemo;uid=sa;pwd=1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

           

            modelBuilder.Entity<Notyf>(entity =>
            {
                entity.ToTable("Notyf");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Username)
                   .HasMaxLength(50)
                   .IsUnicode(false)
                   .HasColumnName("username");

                entity.Property(e => e.Content)
                   .HasMaxLength(50)
                   .IsUnicode(false)
                   .HasColumnName("content");

                entity.Property(e => e.TimeCreate).HasMaxLength(50)
                   .IsUnicode(false).HasColumnName("timeCreate");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
