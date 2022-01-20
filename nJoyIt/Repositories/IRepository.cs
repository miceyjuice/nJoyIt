using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nJoyIt.Repositories
{
    public interface IRepository<T>
    {
        void Add(T obj);
        void Delete(int id);
        IQueryable<T> FindAll();
        T FindById(int id);
    }
}
