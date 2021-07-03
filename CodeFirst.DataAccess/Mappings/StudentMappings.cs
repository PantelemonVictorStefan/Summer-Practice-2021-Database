using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.DataAccess.Mappings
{
    internal abstract class StudentMappings
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(s => s.Id)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(s => s.FirstName)
                .HasColumnName("FirstName")
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .Property(s => s.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Student>()
                .HasOne<Address>(s => s.Address)
                .WithOne(a => a.Student)
                .HasForeignKey<Address>(s=>s.StudentId);
        }
    }
}
