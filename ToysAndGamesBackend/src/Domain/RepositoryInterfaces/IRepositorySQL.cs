using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IRepositorySQL<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(Guid id);
        Task<EntityEntry> AddAsync(TEntity data);
        Task<EntityEntry> DeleteAsync(Guid id);
        EntityEntry Update(TEntity data);
        Task SaveAsync();

    }
}
