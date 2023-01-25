using Domain.Entities;
using Domain.RepositoryInterfaces;
using Domain.UnitOfWorkInterfaces;
using Infraestructure.DataAccess.Data;
using Infraestructure.Repositories;

namespace Infraestructure.UnitsOfWork
{
    public class UnitOfWorkSQL : IUnitOfWorkSQL
    {
        private readonly ToysAndGamesDbContext _context;
        public IRepositorySQL<Product> _products;

        public IRepositorySQL<Product> Products
        {
            get { 
                return _products ?? new RepositorySQL<Product>(_context); 
            }
        }

        public UnitOfWorkSQL(ToysAndGamesDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
