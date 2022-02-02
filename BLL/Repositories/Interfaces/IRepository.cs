using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        T Add(T entity);

        bool Edit(T entity);

        bool Delete(T entity);

        List<T> GetAll();

        T FindByName(string name);

        T FindOne(Expression<Func<T, bool>> filter = null);

        List<T> FindMany(Expression<Func<T, bool>> filter = null);

        //bool Delete(T enity);
    }
}
