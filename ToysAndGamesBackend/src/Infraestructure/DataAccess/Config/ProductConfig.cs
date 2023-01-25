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
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> modelBuilder)
        {
            modelBuilder.Property(a => a.Id).IsRequired();
            modelBuilder.HasIndex(a => a.Id).IsUnique(); // To set UNIQUE constraint to ID

            modelBuilder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Property(a => a.Description)
                .HasMaxLength(100);

            modelBuilder.Property(a => a.CompanyId).IsRequired();
            modelBuilder.HasOne(a => a.Company)
                .WithMany(c => c.Products)
                .HasForeignKey(a => a.CompanyId);

            modelBuilder.Property(a => a.Price)
                .IsRequired()
                .HasColumnType("decimal")
                .HasPrecision(6,2);


            modelBuilder
                .HasData(
                    new Product
                    {
                        Id = Guid.Parse("1D77B12F-5CB3-4651-B1E4-BE186DE93286"),
                        Name = "MaxSteel",
                        Description = "MaxSteel vs Elementor",
                        AgeRestriction = 6,
                        CompanyId = Guid.Parse("87EEB61C-8F5B-4EB7-A6F0-D699DE65C9D2"),
                        Price = 205.85m,
                        ImageURL = "https://www.cinepremiere.com.mx/wp-content/uploads/2020/04/Max-Steel-ranking-.jpg"
                    },
                    new Product
                    {
                        Id = Guid.Parse("7FBACEFC-3380-44FD-B73F-9A3F212A2F46"),
                        Name = "Monopoly",
                        Description = "Nonopoly Marvel",
                        AgeRestriction = 10,
                        CompanyId = Guid.Parse("9995512F-3255-4468-952F-C06D9C89D656"),
                        Price = 498.00m,
                        ImageURL = "https://phantom-elmundo.unidadeditorial.es/8faa10a4f45cce9370d6f3d9d3632ea9/crop/0x213/1198x1009/resize/640/assets/multimedia/imagenes/2020/04/16/15870484935240.jpg"
                    });
        }
    }
}
