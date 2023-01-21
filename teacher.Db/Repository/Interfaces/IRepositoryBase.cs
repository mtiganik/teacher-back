using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace teacher.Db.Repository.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task<IQueryable<T>> FindAllAsync(bool trackChages);
        Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
    }
}
