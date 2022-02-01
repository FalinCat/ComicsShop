using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T entity);

        void Edit(T entity);

        List<T> GetAll();

        T FindByName(string name);

        T FindOne(Expression<Func<T, bool>> filter = null);

        List<T> FindMany(Expression<Func<T, bool>> filter = null);
    }
}
