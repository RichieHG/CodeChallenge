using Domain.Entities;
using Domain.RepositoryInterfaces;

namespace Domain.UnitOfWorkInterfaces
{
    public interface IUnitOfWorkCosmosDB
    {
        //public IRepositorySQL<Product> Products { get; }
        public IRepositoryCosmosDB<Product> Products { get; }

        public Task SaveAsync();
    }
}
