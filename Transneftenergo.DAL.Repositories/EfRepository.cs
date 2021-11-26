using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Transneftenergo.DAL.Interfaces;

namespace Transneftenergo.DAL.Repositories
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        ApplicationContext _db;
        DbSet<TEntity> _dbSet;
        public EfRepository(ApplicationContext applicationContext)
        {
            _db = applicationContext;
            _dbSet = _db.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity item)
        {
            await _dbSet.AddAsync(item);
        }

        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> IsExist(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task SaveAsync()
        {
          await  _db.SaveChangesAsync();
        }
    }
}
