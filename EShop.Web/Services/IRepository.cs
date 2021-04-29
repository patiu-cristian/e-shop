using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Web.Services
{
    public interface IRepository<T>
    {
        void Add(T entity);
        IEnumerable<T> GetAll();
    }
}
