using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ASS_EF.core.Models;

#nullable disable

namespace ASS_EF.core.Context
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DanhBa> DanhBas { get; set; }
        public virtual DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-59GTB0PL\\SQLEXPRESS;Initial Catalog=Ass_DanhBa;Persist Security Info=True;User ID=luudev;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_CI_AS");

            modelBuilder.Entity<DanhBa>(entity =>
            {
                entity.Property(e => e.IdDbPp).ValueGeneratedNever();

                entity.Property(e => e.Mail).IsUnicode(false);

                entity.Property(e => e.Sdt1).IsUnicode(false);

                entity.Property(e => e.Sdt2).IsUnicode(false);

                entity.HasOne(d => d.IdDbPpNavigation)
                    .WithOne(p => p.DanhBa)
                    .HasForeignKey<DanhBa>(d => d.IdDbPp)
                    .HasConstraintName("FK_People_DanhBa");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.IdPp).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
