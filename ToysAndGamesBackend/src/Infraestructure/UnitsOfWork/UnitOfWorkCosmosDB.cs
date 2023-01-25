using Domain.Entities;
using Domain.RepositoryInterfaces;
using Domain.UnitOfWorkInterfaces;
using Infraestructure.DataAccess.Data;
using Infraestructure.Repositories;

namespace Infraestructure.UnitsOfWork
{
    public class UnitOfWorkCosmosDB : IUnitOfWorkCosmosDB
    {
        private readonly ToysAndGamesCosmosDbContext _context;
        public IRepositoryCosmosDB<Product> _products;

        public IRepositoryCosmosDB<Product> Products
        {
            get { 
                return _products ?? new RepositoryCosmosDB<Product>(_context); 
            }
        }

        public UnitOfWorkCosmosDB(ToysAndGamesCosmosDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
