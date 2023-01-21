using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using teacher.Db.Data;
using teacher.Db.Repository.Interfaces;

namespace teacher.Db.Repository.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _repositoryContext;
        protected RepositoryBase(RepositoryContext repositoryContext) 
        {
            _repositoryContext= repositoryContext;
        }
        public async Task<IQueryable<T>> FindAllAsync(bool trackChages) =>
            !trackChages ? await Task.Run(() => _repositoryContext.Set<T>().AsNoTracking()) : await Task.Run(() => _repositoryContext.Set<T>());

        public async Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? await Task.Run(() => _repositoryContext.Set<T>().Where(expression).AsNoTracking()) : await Task.Run(() => _repositoryContext.Set<T>().Where(expression));

        public async Task CreateAsync(T entity) => await Task.Run(() => _repositoryContext.Set<T>().Add(entity));

        public async Task UpdateAsync(T entity) => await Task.Run(() => _repositoryContext.Set<T>().Update(entity));
        public async Task RemoveAsync(T entity) => await Task.Run(() => _repositoryContext.Set<T>().Remove(entity));
    }
}
