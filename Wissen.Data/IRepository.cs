using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wissen.Model;

namespace Wissen.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Find(int id);
        T Find(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> where);
    }
}
