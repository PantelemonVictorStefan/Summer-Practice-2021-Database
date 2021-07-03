using CodeFirst.DataAccess.Mappings;
using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.DataAccess
{
    public class SchoolContext : DbContext
    {
        public SchoolContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source=NBKR004057\SQLEXPRESS;Initial Catalog=SummerPracticeTest;Integrated Security=True";

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            StudentMappings.Map(modelBuilder);
            AddressMappings.Map(modelBuilder);
            GradeMappings.Map(modelBuilder);
            CourseMappings.Map(modelBuilder);
        }

        //entities
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Course> Course { get; set; }
    }
}
