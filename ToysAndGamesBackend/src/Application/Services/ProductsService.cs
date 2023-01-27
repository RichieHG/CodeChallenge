using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.AggregatedModels;
using Domain.Entities;
using Domain.MessagesBrokerInterfaces;
using Domain.Serializer;
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
        private readonly IPublisher _publisher;
        public ProductsService(
            IValidator<Product> validator,
            IMapper mapper,
            IUnitOfWorkSQL unitOfWork,
            IUnitOfWorkCosmosDB unitOfWorkCosmosDB,
            IPublisher publisher)
        {
            _validator = validator;
            _mapper = mapper;
            _unitOfWorkSQL = unitOfWork;
            _unitOfWorkCosmosDB = unitOfWorkCosmosDB;
            _publisher = publisher;
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

            Product createdProduct = (Product) (await _unitOfWorkSQL.Products.AddAsync(newProduct)).Entity;
            await _unitOfWorkSQL.SaveAsync();

            _publisher.PublishMessage(
                CreateMessage<Product>(createdProduct,"Create"),
                "api.public.exchange",
                "subscription");
        }

        public async Task Update(Guid id, ProductDTO product)
        {
            if (id != product.Id) throw new ArgumentException("The id's doesn't match.");

            var productToModify = await GetProduct(id);

            var productWithNewValues = _mapper.Map<Product>(product);

            await ValidateProduct(productWithNewValues);

            // Merging values to save the object reference
            _mapper.Map(productWithNewValues, productToModify);
            Product modifiedProduct = (Product) _unitOfWorkSQL.Products.Update(productToModify).Entity;

            await _unitOfWorkSQL.SaveAsync();

            _publisher.PublishMessage(
                 CreateMessage<Product>(modifiedProduct, "Update"),
                "api.public.exchange",
                "subscription");
        }
        
        public async Task Delete(Guid id)
        {
            await GetProduct(id);
            Product deletedProduct =(Product) (await _unitOfWorkSQL.Products.DeleteAsync(id)).Entity;
            await _unitOfWorkSQL.Products.SaveAsync();

            _publisher.PublishMessage(
                CreateMessage<Product>(deletedProduct, "Delete"),
                "api.public.exchange",
                "subscription");
        }
        
        private async Task<Product> GetProduct(Guid id)
        {
            var product = await _unitOfWorkSQL.Products.GetAsync(id);
            if (product == null) throw new NullReferenceException("Could not find the requested item.");
            return product;
        }

        private async Task ValidateProduct(Product product)
        {
            var result = await _validator.ValidateAsync(product);
            if (!result.IsValid)
                throw new ArgumentException("The following fields are invalid: " +result.ToString());
        }

        private Message<T> CreateMessage<T>(T content, string type)
        {
            return new Message<T> { Type = type, Content = content };
        }

    }
}
