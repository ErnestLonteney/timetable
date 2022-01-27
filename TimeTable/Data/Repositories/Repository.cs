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
        public List<T> GetAll() => _dataContext.Set<T>().ToList();

        public T GetOneByFilter(Expression<Func<T,bool>> filter) => _dataContext.Set<T>().FirstOrDefault(filter);

        public List<T> GetManyByFilter(Expression<Func<T, bool>> filter) => _dataContext.Set<T>().Where(filter).ToList();

        public async Task AddAsync(T entity)
        {
            await _dataContext.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }
    }
}
