using Domain.Entities;
using Domain.RepositoryInterfaces;

namespace Domain.UnitOfWorkInterfaces
{
    public interface IUnitOfWorkSQL
    {
        public IRepositorySQL<Product> Products { get; }

        public Task SaveAsync();
    }
}
