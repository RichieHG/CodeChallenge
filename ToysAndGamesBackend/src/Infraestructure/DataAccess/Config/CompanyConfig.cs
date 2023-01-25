using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.DataAccess.Config
{
    internal class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> modelBuilder)
        {
            modelBuilder.Property(a => a.Id).IsRequired();
            modelBuilder.HasIndex(a => a.Id).IsUnique(); // To set UNIQUE constraint to ID

            modelBuilder.Property(a => a.Name)
               .IsRequired()
               .HasMaxLength(50);

            modelBuilder
                .HasData(
                    new Company
                    {
                        Id = Guid.Parse("87EEB61C-8F5B-4EB7-A6F0-D699DE65C9D2"),
                        Name = "Mattel"
                    },
                    new Company
                    {
                        Id = Guid.Parse("9995512F-3255-4468-952F-C06D9C89D656"),
                        Name = "Hasbro"
                    });
        }
    }
}
