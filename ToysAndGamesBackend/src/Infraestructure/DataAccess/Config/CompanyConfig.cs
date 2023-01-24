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

            modelBuilder.HasData(
                   new Company
                   {
                       Id = 1,
                       Name = "Mattel"
                   },
                   new Company
                   {
                       Id = 2,
                       Name = "Hasbro"
                   }
            );
        }
    }
}
