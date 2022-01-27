using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TimeTable.Data.Repositories
{
    public interface IRepository<T> where T:class
    {
        List<T> GetAll();

        T GetOneByFilter(Expression<Func<T, bool>> filter);

        List<T> GetManyByFilter(Expression<Func<T, bool>> filter);

        Task AddAsync(T entity);
    }
}
