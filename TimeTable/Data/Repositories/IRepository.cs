using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TimeTable.Data.Repositories
{
    public interface IRepository<T> where T:class
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetOneByFilterAsync(Expression<Func<T, bool>> filter);

        Task<List<T>> GetManyByFilterAsync(Expression<Func<T, bool>> filter);

        Task<int> AddAsync(T entity);

        Task<T> GetOneByIdAsync<K>(K id);

        Task<bool> IsExistsAsync<K>(K id);       
    }
}
