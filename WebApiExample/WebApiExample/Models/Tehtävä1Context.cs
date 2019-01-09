using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiExample.Models
{
    public partial class Tehtävä1Context : DbContext
    {
        public Tehtävä1Context()
        {
        }

        public Tehtävä1Context(DbContextOptions<Tehtävä1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Phone> Phone { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-9CKPS05\\SQLEXPRESS;Initial Catalog=Tehtävä1;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.Property(e => e.Number).IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Phone)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_Phone_Person");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}