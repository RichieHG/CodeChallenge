using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using FluentValidation;

namespace Application.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IValidator<Product> _validator;
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _repository;

        public ProductsService(
            IValidator<Product> validator,
            IMapper mapper,
            IRepository<Product> repository)
        {
            _validator = validator;
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<ProductDTO>> Get()
        {
            var products = await _repository.GetAsync();
            products = Enumerable.Empty<Product>();
            return _mapper.Map<List<ProductDTO>>(products);

        }

        public async Task<ProductDTO> Get(int id)
        {
            var product = await _repository.GetAsync(id);
            if (product == null) throw new Exception("Item doesn't exist");
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task Add(ProductDTO product)
        {
            var newProduct = _mapper.Map<Product>(product);
            var result = await _validator.ValidateAsync(newProduct);
            if (!result.IsValid)
                throw new ArgumentException(result.ToString());

            await _repository.AddAsync(newProduct);
            try
            {
                await _repository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(int id, ProductDTO product)
        {
            try
            {
                if (id != product.Id) throw new Exception("Id's doesn't match");

                var modifiedProduct = _mapper.Map<Product>(product);
                var result = await _validator.ValidateAsync(modifiedProduct);
                if (!result.IsValid)
                    throw new ArgumentException(result.ToString());

                _repository.Update(modifiedProduct);

                await _repository.SaveAsync();

            }
            catch
            {
                throw;
            }
        }
        public async Task Delete(int id)
        {
            try
            {
                await Get(id);
                await _repository.DeleteAsync(id);
                await _repository.SaveAsync();
            }
            catch
            {
                throw;
            }
        }

    }
}
