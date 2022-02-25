using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebEntityProject2.Models.EF
{
    public partial class TestDB2Context : DbContext
    {
        public TestDB2Context()
        {
        }

        public TestDB2Context(DbContextOptions<TestDB2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<StudentFees> StudentFees { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-Q684RHH;initial catalog=TestDB2;uid=sa; password=sa123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentFees>(entity =>
            {
                entity.Property(e => e.StudentFeeId).ValueGeneratedNever();

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentFees)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentFees_Students");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__Students__32C52B9957249B9F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
