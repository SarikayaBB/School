using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.Repository.Shared.Abstract
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        bool Add(T entity);
        bool AddRange(IEnumerable<T> entities);
        bool Remove(T entity);
        bool RemoveRange(IEnumerable<T> entities);
        T GetFirstOrDefault(Expression<Func<T,bool>> predicate);
        T Update(T entity);
    }
}
