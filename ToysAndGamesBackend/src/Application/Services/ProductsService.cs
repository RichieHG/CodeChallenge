﻿using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Domain.UnitOfWorkInterfaces;
using FluentValidation;

namespace Application.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IValidator<Product> _validator;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkSQL _unitOfWorkSQL;
        private readonly IUnitOfWorkCosmosDB _unitOfWorkCosmosDB;

        public ProductsService(
            IValidator<Product> validator,
            IMapper mapper,
            IUnitOfWorkSQL unitOfWork,
            IUnitOfWorkCosmosDB unitOfWorkCosmosDB)
        {
            _validator = validator;
            _mapper = mapper;
            _unitOfWorkSQL = unitOfWork;
            _unitOfWorkCosmosDB = unitOfWorkCosmosDB;
        }

        public async Task<IEnumerable<ProductDTO>> Get()
        {
            var products = await _unitOfWorkCosmosDB.Products.GetAsync();
            return _mapper.Map<List<ProductDTO>>(products);

        }

        public async Task<ProductDTO> Get(Guid id)
        {
            var product = await GetProduct(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task Add(ProductDTO product)
        {
            var newProduct = _mapper.Map<Product>(product);
            await ValidateProduct(newProduct);

            await _unitOfWorkCosmosDB.Products.AddAsync(newProduct);
            await _unitOfWorkCosmosDB.SaveAsync();

        }

        public async Task Update(Guid id, ProductDTO product)
        {
            if (id != product.Id) throw new ArgumentException("The id's doesn't match.");

            var productToModify = await GetProduct(id);

            var productWithNewValues = _mapper.Map<Product>(product);

            await ValidateProduct(productWithNewValues);

            // Merging values to save the object reference
            _mapper.Map(productWithNewValues, productToModify);
            _unitOfWorkCosmosDB.Products.Update(productToModify);

            await _unitOfWorkCosmosDB.SaveAsync();
        }
        
        public async Task Delete(Guid id)
        {
            await GetProduct(id);
            await _unitOfWorkCosmosDB.Products.DeleteAsync(id);
            await _unitOfWorkCosmosDB.Products.SaveAsync();
        }
        
        private async Task<Product> GetProduct(Guid id)
        {
            var product = await _unitOfWorkCosmosDB.Products.GetAsync(id);
            if (product == null) throw new NullReferenceException("Could not find the requested item.");
            return product;
        }

        private async Task ValidateProduct(Product product)
        {
            var result = await _validator.ValidateAsync(product);
            if (!result.IsValid)
                throw new ArgumentException("The following fields are invalid: " +result.ToString());
        }
    }
}
