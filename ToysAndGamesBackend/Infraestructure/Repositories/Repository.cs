using Domain.Entities;
using Domain.RepositoryInterfaces;
using Infraestructure.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ToysAndGamesDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(ToysAndGamesDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity data) => await _dbSet.AddAsync(data);

        public async Task<IEnumerable<TEntity>> GetAsync() => await _dbSet.ToListAsync();

        public async Task<TEntity> GetAsync(int id) => await _dbSet.FindAsync(id);

        public void Update(TEntity data)
        {
            _dbSet.Attach(data);
            _context.Entry(data).State = EntityState.Modified;
        }

        public async Task DeleteAsync(int id)
        {
            var dataToDelete = await _dbSet.FindAsync(id);
            _dbSet.Remove(dataToDelete);
        }
        public async Task SaveAsync() => await _context.SaveChangesAsync();

    }
}
