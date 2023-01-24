using Domain.Entities;
using Domain.RepositoryInterfaces;

namespace Domain.UnitOfWorkInterfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Product> Products { get; }

        public Task SaveAsync();
    }
}
