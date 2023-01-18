using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProductService(IValidator<Product> validator, IMapper mapper)
        {
            _validator = validator;
            _mapper = mapper;
        }

        public async void CreateProduct(ProductDTO newProduct)
        {
            var product = _mapper.Map<Product>(newProduct);

            var result = await _validator.ValidateAsync(product);
            Console.WriteLine(result);
        }
    }
}
