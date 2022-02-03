using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IService<T> where T : BaseModel
    {
        T GetByName(string name);

        T Add(T entity);

        bool Edit(T entity);

        bool Delete(T entity);

        List<T> GetManyByFilter(Expression<Func<T, bool>> filter = null);

        T GetOneByFilter(Expression<Func<T, bool>> filter = null);

        List<T> GetAll();

    }
}
