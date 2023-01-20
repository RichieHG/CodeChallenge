using Domain.Entities;
using Domain.RepositoryInterfaces;
using Domain.UnitOfWorkInterfaces;
using Infraestructure.DataAccess.Data;
using Infraestructure.Repositories;

namespace Infraestructure.UnitsOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ToysAndGamesDbContext _context;
        public IRepository<Product> _products;

        public IRepository<Product> Products
        {
            get { 
                return _products ?? new Repository<Product>(_context); 
            }
        }

        public UnitOfWork(ToysAndGamesDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
