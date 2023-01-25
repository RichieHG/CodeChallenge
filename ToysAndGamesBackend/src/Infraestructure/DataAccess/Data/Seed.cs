using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.DataAccess.Data
{
    public class Seed
    {
        public static IEnumerable<Company> Companies = new[]
        {
            new Company
            {
                Id = Guid.Parse("87EEB61C-8F5B-4EB7-A6F0-D699DE65C9D2"),
                Name = "Mattel"
            },
            new Company
            {
                Id = Guid.Parse("9995512F-3255-4468-952F-C06D9C89D656"),
                Name = "Hasbro"
            }

        };

        public static IEnumerable<Product> Products = new[]
        {
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
            }
        };
    }
}
