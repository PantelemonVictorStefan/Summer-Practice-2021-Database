using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.DataAccess.Mappings
{
    internal abstract class CourseMappings
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(s => s.Id)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder.Entity<Course>()
                .Property(s => s.Name)
                .HasColumnName("Name")
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}