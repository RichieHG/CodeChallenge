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
    public class RepositorySQL<TEntity> : IRepositorySQL<TEntity> where TEntity : class
    {
        private readonly ToysAndGamesDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public RepositorySQL(ToysAndGamesDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<EntityEntry> AddAsync(TEntity data) => await _dbSet.AddAsync(data);

        public async Task<IEnumerable<TEntity>> GetAsync() => await _dbSet.ToListAsync();

        public async Task<TEntity> GetAsync(Guid id) => await _dbSet.FindAsync(id);

        public EntityEntry Update(TEntity data) => _dbSet.Update(data);

        public async Task<EntityEntry> DeleteAsync(Guid id)
        {
            var dataToDelete = await _dbSet.FindAsync(id);
            return _dbSet.Remove(dataToDelete);
        }
        public async Task SaveAsync() => await _context.SaveChangesAsync();

    }
}
