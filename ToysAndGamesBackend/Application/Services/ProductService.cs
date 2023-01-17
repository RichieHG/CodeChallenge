using Application.Interfaces;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IValidator<Product> _validator;

        public ProductApplication(IValidator<Product> validator)
        {
            _validator = validator;
        }

        public async void CreateProduct()
        {
            var p = new Product
            {
                Id = 1,
                Name = "MaxSteel",
                Description = "MaxSteel vs Elementor",
                AgeRestriction = 106,
                CompanyId = 1,
                Price = 1205.85m,
                ImageURL = "https://www.cinepremiere.com.mx/wp-content/uploads/2020/04/Max-Steel-ranking-.jpg"
            };

            var result = await _validator.ValidateAsync(p);
            Console.WriteLine(result);
        }
    }
}
