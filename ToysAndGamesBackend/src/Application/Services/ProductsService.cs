using Application.DTOs;
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
        private readonly IUnitOfWork _unitOfWork;

        public ProductsService(
            IValidator<Product> validator,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _validator = validator;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductDTO>> Get()
        {
            var products = await _unitOfWork.Products.GetAsync();
            return _mapper.Map<List<ProductDTO>>(products);

        }

        public async Task<ProductDTO> Get(int id)
        {
            var product = await GetProduct(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task Add(ProductDTO product)
        {
            var newProduct = _mapper.Map<Product>(product);
            await ValidateProduct(newProduct);

            await _unitOfWork.Products.AddAsync(newProduct);
           
            await _unitOfWork.SaveAsync();

        }

        public async Task Update(int id, ProductDTO product)
        {
            if (id != product.Id) throw new ArgumentException("The id's doesn't match.");

            var productToModify = await GetProduct(id);

            var productWithNewValues = _mapper.Map<Product>(product);

            await ValidateProduct(productWithNewValues);

            // Merging values to save the object reference
            _mapper.Map(productWithNewValues, productToModify);
            _unitOfWork.Products.Update(productToModify);

            await _unitOfWork.SaveAsync();
        }
        
        public async Task Delete(int id)
        {
            await GetProduct(id);
            await _unitOfWork.Products.DeleteAsync(id);
            await _unitOfWork.Products.SaveAsync();
        }
        
        private async Task<Product> GetProduct(int id)
        {
            var product = await _unitOfWork.Products.GetAsync(id);
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
