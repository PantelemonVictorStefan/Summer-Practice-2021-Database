using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.DataAccess.Mappings
{
    internal abstract class AddressMappings
    {
        internal static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(s => s.Id)
                .HasColumnName("Id")
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(s => s.City)
                .HasColumnName("City")
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(s => s.Street)
                .HasColumnName("Street")
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
