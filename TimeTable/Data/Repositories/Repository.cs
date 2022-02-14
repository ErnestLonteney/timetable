using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TimeTable.Data.Repositories
{

    public class Repository<T> : IRepository<T> where T:class 
    {
        private readonly TimeTableDataContext _dataContext;

        public Repository()
        {
            _dataContext = new TimeTableDataContext();
        }
        public Task<List<T>> GetAllAsync() => _dataContext.Set<T>().ToListAsync();

        public Task<T> GetOneByFilterAsync(Expression<Func<T,bool>> filter) => _dataContext.Set<T>().FirstOrDefaultAsync(filter);

        public Task<List<T>> GetManyByFilterAsync(Expression<Func<T, bool>> filter) => _dataContext.Set<T>().Where(filter).ToListAsync();

        public async Task<int> AddAsync(T entity)
        {
            await _dataContext.AddAsync(entity);
            return await _dataContext.SaveChangesAsync();
        }

        public async Task<bool> IsExistsAsync<K>(K id) => await _dataContext.Set<T>().FindAsync(id) == null;

        public async Task<T> GetOneByIdAsync<K>(K id) => await _dataContext.Set<T>().FindAsync(id);        
    }
}
