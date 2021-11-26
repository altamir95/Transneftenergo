using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Transneftenergo.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity item) ; 
        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, Boolean>> predicate);
        Task<List<TEntity>> GetListWhereAsync(Expression<Func<TEntity, Boolean>> predicate);
        Task<Boolean> IsExist(Expression<Func<TEntity, Boolean>> predicate);
        Task SaveAsync();
    }
}
